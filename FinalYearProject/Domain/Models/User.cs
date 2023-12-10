﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        //Constructor for creating a new User
        public User(string username, string email, string passwordHash)
        {
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
            IsDeleted = false;
        }

        public void SetPassword(string password)
        {
            // Hash the provided password before storing it
            PasswordHash = HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            //Compare the hashed passwords for verification
            return PasswordHash == HashPassword(password);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        //Methods to Deactivate a User Account
        public void DeactivateAccount()
        {
            IsActive = false;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
