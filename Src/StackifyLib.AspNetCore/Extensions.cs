﻿using System;
using System.Diagnostics;

namespace StackifyLib.AspNetCore
{
    public static class Extensions
    {
        public static void ConfigureStackifyLogging(this Microsoft.AspNetCore.Builder.IApplicationBuilder app,
                Microsoft.Extensions.Configuration.IConfigurationRoot configuration)
        {
            try
            {
                Configure.SubscribeToWebRequestDetails(app.ApplicationServices);

                if (configuration != null)
                {
                    StackifyLib.Config.SetConfiguration(configuration);

                    //tell it to load all the settings since we now have the config
                    Config.LoadSettings();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in AddStackifyLogging " + ex.ToString());
            }
        }
    }
}