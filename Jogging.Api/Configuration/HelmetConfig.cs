namespace Jogging.Api.Configuration
{
    public class HelmetConfig
    {
        private static Dictionary<string, string> headers = new Dictionary<string, string>() {
            {"X-Frame-Options", "DENY" },
            {"X-Xss-Protection", "1; mode=block"},
            {"X-Content-Type-Options", "nosniff"},
            {"Referrer-Policy", "no-referrer"},
            {"X-Permitted-Cross-Domain-Policies", "none"},
            {"Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()"},
            {"Content-Security-Policy", "default-src 'self'"}
        };

        builder.Services.AddAntiforgery(options =>
        {
            options.SuppressXFrameOptionsHeader = true;
        });

        // All pages should be served over https in production "Release" mode:
        if (!builder.Environment.IsDevelopment())
        {
            app.UseHsts();
        }

// Middleware to control headers...
app.Use(async (context, next) =>
{
    foreach (var keyvalue in headers)
    {
        if (!context.Response.Headers.ContainsKey(keyvalue.Key))
        {
            context.Response.Headers.Add(keyvalue.Key, keyvalue.Value);
        }
    }
    await next(context);
});
    }
}