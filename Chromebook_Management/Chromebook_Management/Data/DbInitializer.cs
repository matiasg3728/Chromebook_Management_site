using Chromebook_Management.Models;
using System;
using System.Linq;

namespace Chromebook_Management.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ChromebookManagementContext context)
        {
            context.Database.EnsureCreated();

        }
    }
}