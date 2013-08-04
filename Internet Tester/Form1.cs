/* -========================- License and Distribution -========================-
 * 
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

/* -=========================- About Internet Tester -=========================-
 *  
 *  Internet Tester is designed to be a quick and simple way to see if your
 *  computer has a connection to the Internet. It does this by attempting to
 *  ping a server. If the ping is repeatedly successful, Internet Tester will
 *  say that the Internet is up. If anything goes wrong, or a response
 *  to the ping requests is not received multiple times in a row, Internet
 *  Tester will say that the Internet is down.
 *  
 *  Ultimately, the goal of this application is to save the user from having
 *  to go to the command prompt to check the Internet connection.
 * 
 *  If you wish to contact me about the application, or anything of the like,
 *  feel free to send me an email at coolcord24@gmail.com
 */

/* -================================- Credits -================================-
 *  
 *  The following files and content included with Internet Tester (though some modified)
 *  were not originally created by me. Credit shall be given where it is due!
 * 
 *  fail.png:
 *      Vinyl Scratch is from My Little Pony: Friendship is Magic © Hasbro
 *      Image by namelesshero2222
 *      
 *  success.png:
 *      Vinyl Scratch is from My Little Pony: Friendship is Magic © Hasbro
 *      Image by namelesshero2222
 *      
 *  suspicous.png:
 *      Vinyl Scratch is from My Little Pony: Friendship is Magic © Hasbro
 *      Image by namelesshero2222
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Internet_Tester
{
    public partial class Form1 : Form
    {
        Boolean FirstConnection = true;
        Boolean PreviouslyConnected = false;
        string host = "www.google.com";
        int DeathCount = 0;

        public Form1()
        {
            InitializeComponent();
            InternetTestBW.RunWorkerAsync();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            Form aboutForm = new Form() { FormBorderStyle = FormBorderStyle.FixedSingle, MinimizeBox = false, MaximizeBox = false };
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.Width = 400;
            aboutForm.Height = 200;
            aboutForm.Text = "About Internet Tester";
            aboutForm.Icon = Internet_Tester.Properties.Resources.Internet_Tester;

            //Get the version number
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            Label aboutText = new Label()
            {
                Width = 400,
                Height = 130,
                Location = new Point(0, 0),
                ImageAlign = ContentAlignment.MiddleCenter,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Internet Tester v" + fileVersionInfo.ProductMajorPart + "." + fileVersionInfo.ProductMinorPart + "." + fileVersionInfo.ProductBuildPart + "\n\n" +
                    "A Simple Program to Quickly\n" + "Check the Internet Connection\n\n" +
                    "Programmed and Designed by Coolcord"
            };
            Font aboutFont = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            aboutText.Font = aboutFont;
            Button btnOk = new Button() { Width = 100, Height = 30, Text = "OK", Location = new Point(150, 130), ImageAlign = ContentAlignment.MiddleCenter, TextAlign = ContentAlignment.MiddleCenter };
            btnOk.Click += (btnSender, btnE) => aboutForm.Close(); //click ok to close
            aboutForm.Controls.Add(aboutText);
            aboutForm.Controls.Add(btnOk);
            aboutForm.ShowDialog();
            aboutForm.Dispose();
            btnOk.Dispose();
            aboutText.Dispose();
            aboutFont.Dispose();
        }

        private Boolean CheckHostname()
        {
            if (host == "www.google.com")
            {
                try
                {
                    IPAddress[] addresslist = Dns.GetHostAddresses(host); //get the IP from the DNS hostname
                    IPAddress address;
                    if (IPAddress.TryParse(addresslist[0].ToString(), out address)) //check what was returned to see if it is valid
                    {
                        if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork || //IPv4
                            address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) //IPv6
                        {
                            host = addresslist[0].ToString(); //save the IP
                            return true;
                        }
                    }
                }
                catch { }
                return false;
            }
            else
                return true;
        }

        private Boolean IsConnectedToInternet()
        {
            Boolean result = false;
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(host, 1000); //expect a response within 1 second
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }
            finally
            {
                ping.Dispose();
            }
            return result;
        }

        private void SetInternetConnectionState(Boolean connected)
        {
            if (connected == PreviouslyConnected && !FirstConnection)
                return; //don't change the state
            if (connected == true) //Internet is up
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        lblStatus.Text = "Internet is Up!";
                        lblStatus.ForeColor = Color.LightGreen;
                        pbStatus.Image = Internet_Tester.Properties.Resources.success;
                    }));
                }
                catch { }
            }
            else //Internet is down
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        lblStatus.Text = "Internet is Down!";
                        if (!FirstConnection) //only set the death if it is not the first time trying to connect
                        {
                            DeathCount++;
                            if (DeathCount == 1)
                                lblDeathCount.Text = "The Internet has died " + DeathCount + " time!";
                            else
                                lblDeathCount.Text = "The Internet has died " + DeathCount + " times!";
                        }
                        lblStatus.ForeColor = Color.Red;
                        pbStatus.Image = Internet_Tester.Properties.Resources.fail;
                    }));
                }
                catch { }
            }
            PreviouslyConnected = connected; //save the state as previous
            if (FirstConnection)
                FirstConnection = false;
        }

        private void InternetTestBW_DoWork(object sender, DoWorkEventArgs e)
        {
            while (host == "www.google.com")
            {
                if (!CheckHostname()) //make sure the hostname has been resolved to an IP
                    SetInternetConnectionState(false);
            }
            int state = 0;
            while (true)
            {
                if (IsConnectedToInternet())
                {
                    if (state < 0) //first success
                        state = 1;
                    else if (state == 3) //multiple successes
                    {
                        SetInternetConnectionState(true);
                        state++;
                    }
                    else if (state > 4) //maximum successes reached
                    {
                        state = 4;
                        System.Threading.Thread.Sleep(3000); //only sleep on success
                    }
                    else
                        state++;
                }
                else
                {
                    if (state > 0) //first fail
                        state = -1;
                    else if (state == -3) //multiple fails
                    {
                        SetInternetConnectionState(false);
                        state--;
                    }
                    else if (state < -4) //max fails reached
                        state = -4;
                    else
                        state--;
                }
            }
        }
    }
}
