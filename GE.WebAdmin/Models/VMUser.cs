﻿using System.Text;

namespace GE.WebAdmin.Models
{
    public sealed class VMUser
    {
        public string Id { get; set; }
        public string NikName { get; set; }
        public string Email { get; set; }
        public VMRole[] Roles { get; set; }
        public string RoleNames
        {
            get
            {
                var sb=new StringBuilder();
                for (int i = 0; i < this.Roles.Length; i++)
                {
                    sb.Append("; " + this.Roles[i].Name);
                }
                sb.Remove(0, 2);
                return sb.ToString();
            }
        }
    }
}