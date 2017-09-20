using FuglBrennaMvc.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace FuglBrennaMvc {
    public class MemberUserStore : IUserStore<MemberLogin, int>, IUserPasswordStore<MemberLogin, int>, IUserEmailStore<MemberLogin, int> {
        private readonly FuglBrennaEntities context;

        public MemberUserStore(FuglBrennaEntities context) {
            this.context = context;
        }

        public Task CreateAsync(MemberLogin user) {
            this.context.MemberLogins.Add(user);
            this.context.SaveChanges();

            return Task.FromResult(user);
        }

        public Task DeleteAsync(MemberLogin user) {
            this.context.MemberLogins.Remove(user);
            var result = this.context.SaveChanges();
            return Task.FromResult(result);
        }

        public void Dispose() {
            
        }

        public Task<MemberLogin> FindByEmailAsync(string email) {
            return Task.FromResult(this.context.MemberLogins.SingleOrDefault(x => x.Email == email));
        }

        public Task<MemberLogin> FindByIdAsync(int userId) {
            return Task.FromResult(this.context.MemberLogins.Find(userId));
        }

        public Task<MemberLogin> FindByNameAsync(string username) {
            return Task.FromResult(this.context.MemberLogins.SingleOrDefault(x => x.Email == username));
        }

        public Task<string> GetEmailAsync(MemberLogin user) {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(MemberLogin user) {
            return Task.FromResult(true);
        }

        public Task<string> GetPasswordHashAsync(MemberLogin user) {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(MemberLogin user) {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task SetEmailAsync(MemberLogin user, string email) {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task SetEmailConfirmedAsync(MemberLogin user, bool confirmed) {
            return Task.FromResult(0);
        }

        public Task SetPasswordHashAsync(MemberLogin user, string passwordHash) {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task UpdateAsync(MemberLogin user) {
            this.context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            return Task.FromResult(this.context.SaveChanges());
        }
    }
}