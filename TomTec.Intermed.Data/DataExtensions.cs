using System;
using System.Collections.Generic;
using System.Text;
using TomTec.Intermed.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace TomTec.Intermed.Data
{
    public static class DataExtensions
    {
        public static IEnumerable<User> GetCompleteUsers(this IntermedDBContext context)
        {
            return context.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.Claim)}");
        }

        public static IEnumerable<User> GetCompleteUsers(this IntermedDBContext context, Func<User, bool> query)
        {
            return context.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.Claim)}")
                .Where(query);
        }

        public static User GetCompleteUserByEmail(this IntermedDBContext context, string email)
        {
            return context.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.Claim)}")
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public static User GetCompleteUserByUserName(this IntermedDBContext context, string userName)
        {
            return context.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.Claim)}")
                .FirstOrDefault(u => u.UserName.Equals(userName));
        }

        public static User GetCompleteUserById(this IntermedDBContext context, int Id)
        {
            return context.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.Claim)}")
                .FirstOrDefault(u => u.Id == Id);
        }

        public static Claim GetCompleteUserClaim(this IntermedDBContext context, int Id)
        {
            return context.Claims
                .Include(nameof(Claim.UsersClaims))
                .Include($"{nameof(Claim.UsersClaims)}.{nameof(UsersClaims.User)}")
                .FirstOrDefault(ut => ut.Id == Id);
        }

        public static IEnumerable<Claim> GetCompleteUserClaims(this IntermedDBContext context, Func<Claim, bool> query)
        {
            return context.Claims
                .Include(nameof(Claim.UsersClaims))
                .Include($"{nameof(Claim.UsersClaims)}.{nameof(UsersClaims.User)}")
                .Where(query);
        }

        public static IEnumerable<Claim> GetCompleteUserClaims(this IntermedDBContext context)
        {
            return context.Claims
                .Include(nameof(Claim.UsersClaims))
                .Include($"{nameof(Claim.UsersClaims)}.{nameof(UsersClaims.User)}");
        }


        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
            {
                //query = includes.Aggregate(query,
                //          (current, include) => current.Include(include));

                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
