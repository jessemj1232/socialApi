using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using socialApi.Models;

namespace socialApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<UserContext>(opt =>
                opt.UseInMemoryDatabase("UsersList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<PostContext>(opt =>
                opt.UseInMemoryDatabase("PostsList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<FollowingContext>(opt =>
                opt.UseInMemoryDatabase("FollowersList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<CommentLikeContext>(opt =>
                opt.UseInMemoryDatabase("CommentLikesList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<CommentContext>(opt =>
                opt.UseInMemoryDatabase("CommentsList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<PostLikeContext>(opt =>
                opt.UseInMemoryDatabase("PostLikesList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}