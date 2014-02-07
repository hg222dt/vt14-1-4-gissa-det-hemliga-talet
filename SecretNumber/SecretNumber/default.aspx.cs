using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecretNumber
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //få ut ett slumpat hemligt tal
        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {
            //Jämföra gissat tal med sparade tal
            //Ev skriva ut lämpligt meddelande
            //låsa fält och knappar om rätt gissning gjorts eller om gissningar är slut
        }

        protected void NewGameButton_Click(object sender, EventArgs e)
        {
            //få ut nytt slumpat hemligt tal.

        }
    }
}