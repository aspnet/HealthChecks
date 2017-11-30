// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Couchbase;
using Couchbase.Management;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;

namespace Microsoft.Extensions.HealthChecks
{
    // REVIEW: What are the appropriate guards for these functions?

    public static class HealthCheckBuilderCouchbaseServerExtensions
    {
        public static HealthCheckBuilder AddCouchbaseCheck(this HealthCheckBuilder builder, IServiceCollection services, TimeSpan? cacheDuration = null)
        {
            Guard.ArgumentNotNull(nameof(builder), builder);

            services.AddSingleton<CouchbaseHealthCheck>();
            builder.AddCheck<CouchbaseHealthCheck>(CouchbaseHealthCheck.Tag, cacheDuration ?? builder.DefaultCacheDuration);

            return builder;
        }
    }
}
