using System;
using System.Collections.Generic;
using System.Text;
using TomTec.Intermed.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace TomTec.Intermed.Data
{
    public static class RepositoryExtensions
    {
        public static IEnumerable<User> GetComplete(this IRepository<User> repository)
        {
            return repository.DBContext.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.Claim)}");
        }

        public static IEnumerable<User> GetComplete(this IRepository<User> repository, Func<User, bool> query)
        {
            return repository.DBContext.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.Claim)}")
                .Where(query);
        }

        public static User GetCompleteUserByEmail(this IRepository<User> repository, string email)
        {
            return repository.DBContext.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.Claim)}")
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public static User GetCompleteUserByUserName(this IRepository<User> repository, string userName)
        {
            return repository.DBContext.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.Claim)}")
                .FirstOrDefault(u => u.UserName.Equals(userName));
        }

        public static User GetComplete(this IRepository<User> repository, int Id)
        {
            return repository.DBContext.Users
                .Include(nameof(User.Address))
                .Include(nameof(User.UserType))
                .Include($"{nameof(User.UsersClaims)}.{nameof(UsersClaims.Claim)}")
                .FirstOrDefault(u => u.Id == Id);
        }

        public static Claim GetComplete(this IRepository<Claim> repository, int Id)
        {
            return repository.DBContext.Claims
                .Include(nameof(Claim.UsersClaims))
                .Include($"{nameof(Claim.UsersClaims)}.{nameof(UsersClaims.User)}")
                .FirstOrDefault(ut => ut.Id == Id);
        }

        public static IEnumerable<Claim> GetComplete(this IRepository<Claim> repository, Func<Claim, bool> query)
        {
            return repository.DBContext.Claims
                .Include(nameof(Claim.UsersClaims))
                .Include($"{nameof(Claim.UsersClaims)}.{nameof(UsersClaims.User)}")
                .Where(query);
        }

        public static IEnumerable<Claim> GetComplete(this IRepository<Claim> repository)
        {
            return repository.DBContext.Claims
                .Include(nameof(Claim.UsersClaims))
                .Include($"{nameof(Claim.UsersClaims)}.{nameof(UsersClaims.User)}");
        }

        public static void SignUserToClaim(this IRepository<Claim> repository, int userId, int claimId)
        {
            var userClaim = new UsersClaims(userId, claimId);
            repository.DBContext.UsersClaims.Add(userClaim);
            repository.DBContext.SaveChanges();
        }

        public static void UnsignUserToClaim(this IRepository<Claim> repository, int userId, int claimId)
        {
            var userClaim = new UsersClaims(userId, claimId);
            repository.DBContext.UsersClaims.Remove(userClaim);
            repository.DBContext.SaveChanges();
        }

        public static void Cancell(this IRepository<Signature> repository, int id)
        {
            var signature = new Signature()
            {
                Id = id,
                IsCancelled = true
            };

            repository.DBContext.Signatures.Attach(signature);
            repository.DBContext.Entry(signature).Property(x => x.IsCancelled).IsModified = true;
            repository.DBContext.SaveChanges();
        }

        public static void Cancell(this IRepository<User> repository, int id)
        {
            var user
                = new User()
            {
                Id = id,
                Active = false
            };

            repository.DBContext.Users.Attach(user);
            repository.DBContext.Entry(user).Property(x => x.Active).IsModified = true;
            repository.DBContext.SaveChanges();
        }

        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
