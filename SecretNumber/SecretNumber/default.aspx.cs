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
        private Model.SecretNumber Game
        {
            //Skapar ny session
            get
            {
                if (Session["game"] == null)
                {
                    Session["game"] = new Model.SecretNumber();
                    return (Model.SecretNumber)Session["game"];
                }
                else
                {
                    return (Model.SecretNumber)Session["game"];
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //När "gissa"-knapp klickas
        protected void GuessButton_Click(object sender, EventArgs e)
        {   
            if(IsValid)
            {
                //Tar in gissning från textbox
                int guess = int.Parse(GuessInput.Text);

                //Enum sätts till ett visst värde genom att gissnings-metod anropas och argument skickas med i form av det inmatade talet.
                Model.Outcome status = Game.MakeGuess(guess);


                //Gjorda gissningar skrivs ut.
                string str = "Gjorda gissningar: ";

                foreach (int i in Game.PreviousGuesses)
                {
                    str += string.Format("{0} ", i.ToString());
                }

                GuessedNumbTxt.Text = str;   


                //Olika teter skrivs ut och fält låses beroende på vilken status senaste gissningen fått.
                if(status == Model.Outcome.Low)
                {
                    ResultTxt.Text = String.Format("<img src='Images/arrow.png' id='lowArrow' class='imgIcon' /> För lågt!");
                }
                else if(status == Model.Outcome.High)
                {
                    ResultTxt.Text = String.Format("<img src='Images/arrow.png' id='highArrow' class='imgIcon' /> För högt!");
                }
                else if(status == Model.Outcome.Correct)
                {
                    ResultTxt.Text = String.Format("<img src='Images/done.png' class='imgIcon' /> Grattis du gissade på rätt tal! Det tog dig {0} gissningar!", Game.Count);

                    //Låser fält.
                    GuessInput.Enabled = false;
                    GuessButton.Enabled = false;
                }
                else if(status == Model.Outcome.PreviousGuess)
                {
                    ResultTxt.Text = String.Format(" <img src='Images/excl.gif' class='imgIcon' /> Gissningen var på ett tidigare gissat tal. Gör om gissningen");
                }

                if(status == Model.Outcome.NoMoreGuesses)
                {
                    FinalResultTxt.Text = String.Format(" <img src='Images/fail.jpg' class='imgIcon' /> Du har tyvär inga gissningar kvar! Det hemliga talet var: {0}", Game.Number);

                    //Låser fält.
                    GuessInput.Enabled = false;
                    GuessButton.Enabled = false;

                    //Synliggör knapp för nytt spel.
                    NewGameButton.Visible = true;
                }
            }
        }

        //Knapp för nytt spel
        protected void NewGameButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("default.aspx");
        }
    }
}