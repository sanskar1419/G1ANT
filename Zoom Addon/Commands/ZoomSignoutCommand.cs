﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Zoom
{

    [Command(Name = "zoom.signout", Tooltip = "This command is used to sign out from zoom")]
    public class ZoomSignoutCommand : Command
    {
        public ZoomSignoutCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(3000);
                SeleniumManager.CurrentWrapper.Navigate("https://us04web.zoom.us/profile", arguments.Timeout.Value, arguments.NoWait.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/div[1]/div[2]/div[2]/div/ul[2]/li[7]/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/div[1]/div[2]/div[2]/div/ul[2]/li[7]/div/a[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}