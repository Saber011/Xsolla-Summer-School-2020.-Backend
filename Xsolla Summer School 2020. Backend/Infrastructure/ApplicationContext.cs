﻿using Common.News.Dto;
using Common.Users.Dto;
using Microsoft.EntityFrameworkCore;

namespace Xsolla_Summer_School_2020._Backend.Infrastructure
{
    /// <summary>
    /// Работа с бд.
    /// </summary>
    public sealed class ApplicationContext : DbContext
    {
        /// <summary>
        /// Пользователи.
        /// </summary>
        public DbSet<UserDto> Users { get; set; }

        /// <summary>
        /// Роли.
        /// </summary>
        public DbSet<RoleDto> Roles { get; set; }

        /// <summary>
        /// Журнал ролей.
        /// </summary>
        public DbSet<UserRolesDto> UserRoles { get; set; }

        /// <summary>
        /// Новости.
        /// </summary>
        public DbSet<NewsDto> News { get; set; }

        /// <summary>
        /// Категории.
        /// </summary>
        public DbSet<CategoriesDto> Categories { get; set; }

        /// <summary>
        /// Журнал просмотренных новостей.
        /// </summary>
        public DbSet<UserLikesNewsDto> UserLikesNews { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
