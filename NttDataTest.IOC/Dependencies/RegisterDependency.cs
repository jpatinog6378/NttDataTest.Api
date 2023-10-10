using Microsoft.Extensions.DependencyInjection;
using NttDataTest.CORE.Core.Author;
using NttDataTest.CORE.Core.Author.Interface;
using NttDataTest.CORE.Core.Book;
using NttDataTest.CORE.Core.Book.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttDataTest.IOC.Dependencies
{
    public class RegisterDependency
    {
        public static void RegisterDependencies(IServiceCollection service) 
        {
            service.AddScoped<IAuthorCore, AuthorCore>();
            service.AddScoped<IBookCore, BookCore>();
        }
    }
}
