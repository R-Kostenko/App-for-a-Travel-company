using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency_temp.Classes
{
    // Interface for the chain of responsibility pattern, defines methods to check and set the next handler.
    public interface IHandler
    {
        void Check();
        void setNext(IHandler handler);
    }


    // BaseHandler abstract class implements the IHandler interface and holds common properties and methods.
    public abstract class BaseHandler : IHandler
    {
        protected IHandler next;
        protected string textCheck;
        protected Panel panel;

        // Constructor to initialize textCheck and panel properties.
        public BaseHandler(string textCheck, ref Panel panel)
        {
            this.textCheck = textCheck;
            this.panel = panel;
        }

        // Method to set the next handler in the chain.
        public void setNext(IHandler handler)
        {
            this.next = handler;
        }

        // Abstract method for handling the check. Implemented in derived classes.
        public abstract void Check();
    }


    // CheckName class is a concrete handler that checks if the input is a valid name.
    public class CheckName : BaseHandler
    {
        // Constructor to initialize textCheck and panel properties via the base class.
        public CheckName(string textCheck, ref Panel panel) : base(textCheck, ref panel) { }

        // Check method to validate the input as a name.
        public override void Check()
        {
            if (!Regex.IsMatch(textCheck, "[А-Яа-я]+$"))
            {
                panel.BackColor = Color.Red;
            }
            next?.Check();  // Call the check method of the next handler in the chain, if next is not equal to null.
        }
    }

    //!!! Other classes (CheckGender, CheckPassword, etc.) follow a similar structure, checking different input fields.

    public class CheckGender : BaseHandler
    {
        private ComboBox comboBox;
        public CheckGender(ComboBox comboBox , ref Panel panel) : base("", ref panel) 
        {
            this.comboBox = comboBox;
        }

        public override void Check()
        {
            if (comboBox.SelectedItem == null)
            {
                panel.BackColor = Color.Red;
            }
            next?.Check();
        }
    }

    public class CheckPassword : BaseHandler
    {
        public CheckPassword(string textCheck, ref Panel panel) : base(textCheck, ref panel) { }

        public override void Check()
        {
            if (!Regex.IsMatch(textCheck, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d!@#$%^&*]{8,256}$"))
            {
                panel.BackColor = Color.Red;
            }
            next?.Check();
        }
    }

    public class CheckPasswords : BaseHandler
    {
        private string password1, password2;
        public CheckPasswords(string password1, string password2, ref Panel panel) : base("", ref panel)
        { 
            this.password1 = password1;
            this.password2 = password2;
        }

        public override void Check()
        {
            if (password1 != password2)
            {
                panel.BackColor = Color.Red;
            }
            next?.Check();
        }
    }

    public class CheckEmail : BaseHandler
    {
        public CheckEmail(string textCheck, ref Panel panel) : base(textCheck, ref panel) { }

        public override void Check()
        {
            if (!Regex.IsMatch(textCheck, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                panel.BackColor = Color.Red;
            }
            next?.Check();
        }
    }

    public class CheckPhone : BaseHandler
    {
        public CheckPhone(string checkText, ref Panel panel) : base(checkText, ref panel) { }

        public override void Check()
        {
            if (!Regex.IsMatch(textCheck, "^[+][3][8][0][0-9]{7,13}$"))
            {
                panel.BackColor = Color.Red;
            }
            next?.Check();
        }
    }

    public class CheckTourNameOrSubject : BaseHandler
    {
        public CheckTourNameOrSubject(string textCheck, ref Panel panel) : base(textCheck, ref panel) { }

        public override void Check()
        {
            if (!Regex.IsMatch(textCheck, "[А-Яа-яA-Za-zіїІЇ\\s.:!`]+$"))
            {
                panel.BackColor = Color.Red;
            }
            next?.Check();
        }
    }

    public class CheckDescriptionOrBody : BaseHandler
    {
        public CheckDescriptionOrBody(string textCheck, ref Panel panel) : base(textCheck, ref panel) { }

        public override void Check()
        {
            if (!Regex.IsMatch(textCheck, "[А-Яа-яA-Za-zіїІЇ.:;*/!?$()\\s-+=`]+$"))
            {
                panel.BackColor = Color.Red;
            }
            next?.Check();
        }
    }

    public class CheckCountOrPrice : BaseHandler
    {
        public CheckCountOrPrice(string textCheck, ref Panel panel) : base(textCheck, ref panel) { }

        public override void Check()
        {
            if (!Regex.IsMatch(textCheck, "[0-9]+$"))
            {
                panel.BackColor = Color.Red;
            }
            next?.Check();
        }
    }
}
