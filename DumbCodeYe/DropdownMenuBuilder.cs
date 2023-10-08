using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe
{
    public class DropdownMenuBuilder
    {
        private Form _form;
        private List<Button> _buttons = new List<Button>();

        public const int BUTTON_HEIGHT = 40;

        public DropdownMenuBuilder(Form form)
        {
            _form = form;
        }

        /// <summary>
        /// Opens a drowdown menu on the form
        /// </summary>
        public void OpenDropdown(ButtonInformation[] buttons, Point startingPoint)
        {
            CloseDropdown();
            for (int i = 0; i < buttons.Length; i++)
            {
                Button button = CreateButton(buttons[i], new Point(startingPoint.X, startingPoint.Y + BUTTON_HEIGHT * i), i);
                _form.Controls.Add(button);
                _buttons.Add(button);
                button.BringToFront();
            }
        }

        /// <summary>
        /// Closes the previous dropdown
        /// </summary>
        public void CloseDropdown()
        {
            foreach(Button button in _buttons)
            {
                _form.Controls.Remove(button);
            }
            _buttons.Clear();
        }

        private Button CreateButton(ButtonInformation information, Point position, int index)
        {
            Button button = new Button();

            button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            button.FlatAppearance.BorderSize = 2;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            button.Location = position;
            button.Size = new System.Drawing.Size(300, BUTTON_HEIGHT);
            button.TabIndex = index + 20;
            button.Text = information.Text;
            button.UseVisualStyleBackColor = false;
            button.Click += information.OnClick;

            return button;
        }
    }
}
