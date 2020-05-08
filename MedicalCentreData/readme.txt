Create Models folder

Create your class under Models

Create the controller for the model under the Controllers folder

Remove the value of launchUrl which by default is WeatherForecast to be empty like "". There are two launchUrls

Create folder Pages

Add a Razor Page under Pages. A blank Razor Page with the name Index

Add services.AddRazorPages(); under the line services.AddControllers();

Add: app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); }); under app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

Build the project

In Nuget Manager Console, write add-migration -Context nameOfYourContext. The nameOfYourContext should be in Data folder.

It will ask for a name. Give it a name that is different than the context. You can add a simple DB to the name

Run the command update-database



Then change the names from Emp to your own table

Copy the JQuery texts from Index in Pages to your Index

Change the links of your JQuery file