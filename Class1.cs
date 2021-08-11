using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.ComponentModel;
namespace CalculatorGrid
{

    public class Program : ContentPage
    {
        public static void Main()
        {
            Ui.RunOnUiThread(() =>
            {

                var width = DeviceDisplay.MainDisplayInfo.Width;
                var height = DeviceDisplay.MainDisplayInfo.Height;

                Grid grid = new Grid
                {
                    Margin = 0,
                    Padding = 0,
                    RowSpacing = 0,
                    ColumnSpacing = 0,
                    RowDefinitions =
                    {
                        new RowDefinition(),
                        new RowDefinition(),
                        new RowDefinition(),
                        new RowDefinition(),
                        new RowDefinition(),
                        new RowDefinition(),
                        new RowDefinition()
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition(),
                        new ColumnDefinition()
                    }

                };

                Button b0 = new Button
                {
                    Text = "0",
                    BackgroundColor = Color.Gray,
                    BorderWidth = 0
                };

                Button b1 = new Button
                {
                    Text = "1",
                    BackgroundColor = Color.Gray,
                    BorderWidth = 0
                };

                Button b2 = new Button
                {
                    Text = "2",
                    BackgroundColor = Color.Gray,
                    BorderWidth = 0
                };

                Button b3 = new Button
                {
                    Text = "3",
                    BackgroundColor = Color.Gray,
                    BorderWidth = 0
                };

                Button b4 = new Button
                {
                    Text = "4",
                    BackgroundColor = Color.Gray,
                    BorderWidth = 0
                };

                Button b5 = new Button
                {
                    Text = "5",
                    BackgroundColor = Color.Gray,
                    BorderWidth = 0
                };

                Button b6 = new Button
                {
                    Text = "6",
                    BackgroundColor = Color.Gray,
                    BorderWidth = 0
                };

                Button b7 = new Button
                {
                    Text = "7",
                    BackgroundColor = Color.Gray,
                    BorderWidth = 0
                };

                Button b8 = new Button
                {
                    Text = "8",
                    BackgroundColor = Color.Gray,
                    BorderWidth = 0
                };

                Button b9 = new Button
                {
                    Text = "9",
                    BackgroundColor = Color.Gray,
                    BorderWidth = 0
                };

                Button add = new Button
                {
                    Text = "+",
                    BackgroundColor = Color.Orange,
                    BorderWidth = 0
                };

                Button equals = new Button
                {
                    Text = "=",
                    BackgroundColor = Color.Orange,
                    BorderWidth = 0
                };
                Button comma = new Button
                {
                    Text = ",",
                    BackgroundColor = Color.Gray,
                    BorderWidth = 0
                };

                Button clear = new Button
                {
                    Text = "C",
                    BackgroundColor = Color.Red,
                    BorderWidth = 0
                };

                Button negative = new Button
                {
                    Text = "+-",
                    BackgroundColor = Color.Gray,
                    BorderWidth = 0
                };

                Button div = new Button
                {
                    Text = "/",
                    BackgroundColor = Color.Orange,
                    BorderWidth = 0
                };

                Button mul = new Button
                {
                    Text = "×",
                    BackgroundColor = Color.Orange,
                    BorderWidth = 0
                };

                Button min = new Button
                {
                    Text = "-",
                    BackgroundColor = Color.Orange,
                    BorderWidth = 0
                };

                Button remove = new Button
                {
                    Text = "<--",
                    BackgroundColor = Color.OrangeRed,
                    BorderWidth = 0
                };

                Button bracket = new Button
                {
                    Text = "()",
                    BackgroundColor = Color.Orange,
                    BorderWidth = 0
                };

                Button mod = new Button
                {
                    Text = "mod",
                    BackgroundColor = Color.OrangeRed,
                    BorderWidth = 0
                };

                Button perc = new Button
                {
                    Text = "%",
                    BackgroundColor = Color.Orange,
                    BorderWidth = 0
                };

                Label enteredValue = new Label
                {
                    MaxLines = 2,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    FontSize = 25
                };
                Calculator.current = enteredValue;

                Label outputValue = new Label
                {
                    MaxLines = 2,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    FontSize = 15
                };
                Calculator.outputValue = outputValue;

                b0.Clicked += async (sender, args) => Calculator.AddValue('0');
                b1.Clicked += async (sender, args) => Calculator.AddValue('1');
                b2.Clicked += async (sender, args) => Calculator.AddValue('2');
                b3.Clicked += async (sender, args) => Calculator.AddValue('3');
                b4.Clicked += async (sender, args) => Calculator.AddValue('4');
                b5.Clicked += async (sender, args) => Calculator.AddValue('5');
                b6.Clicked += async (sender, args) => Calculator.AddValue('6');
                b7.Clicked += async (sender, args) => Calculator.AddValue('7');
                b8.Clicked += async (sender, args) => Calculator.AddValue('8');
                b9.Clicked += async (sender, args) => Calculator.AddValue('9');
                comma.Clicked += async (sender, args) => Calculator.AddValue(',');
                add.Clicked += async (sender, args) => Calculator.AddOp('+');
                equals.Clicked += async (sender, args) => Calculator.Equals();
                clear.Clicked += async (sender, args) => Calculator.Clear();
                negative.Clicked += async (sender, args) => Calculator.MakeCurrentNumberNegOrPos();
                div.Clicked += async (sender, args) => Calculator.AddOp('/');
                mul.Clicked += async (sender, args) => Calculator.AddOp('*');
                min.Clicked += async (sender, args) => Calculator.AddOp('-');
                remove.Clicked += async (sender, args) => Calculator.Remove();
                bracket.Clicked += async (sender, args) => Calculator.AddBracket();
                mod.Clicked += async (sender, args) => Calculator.AddOp('m');
                perc.Clicked += async (sender, args) => Calculator.AddOp('÷');

                grid.Children.Add(enteredValue, 0, 3, 0, 1);
                grid.Children.Add(outputValue, 3, 4, 0, 1);

                grid.Children.Add(remove, 3, 4, 1, 2);
                grid.Children.Add(mod, 0, 1, 1, 2);

                grid.Children.Add(clear, 0, 1, 2, 3);
                grid.Children.Add(bracket, 1, 2, 2, 3);
                grid.Children.Add(div, 2, 3, 2, 3);
                grid.Children.Add(perc, 3, 4, 2, 3);

                grid.Children.Add(b7, 0, 1, 3, 4);
                grid.Children.Add(b8, 1, 2, 3, 4);
                grid.Children.Add(b9, 2, 3, 3, 4);
                grid.Children.Add(mul, 3, 4, 3, 4);

                grid.Children.Add(b4, 0, 1, 4, 5);
                grid.Children.Add(b5, 1, 2, 4, 5);
                grid.Children.Add(b6, 2, 3, 4, 5);
                grid.Children.Add(min, 3, 4, 4, 5);

                grid.Children.Add(b1, 0, 1, 5, 6);
                grid.Children.Add(b2, 1, 2, 5, 6);
                grid.Children.Add(b3, 2, 3, 5, 6);
                grid.Children.Add(add, 3, 4, 5, 6);

                grid.Children.Add(negative, 0, 1, 6, 7);
                grid.Children.Add(b0, 1, 2, 6, 7);
                grid.Children.Add(comma, 2, 3, 6, 7);
                grid.Children.Add(equals, 3, 4, 6, 7);

                Ui.LoadMainLayout(grid);
            });
        }
    }

    public static class Calculator
    {
        public static char operation = 's';

        public static Label current;
        public static Label outputValue;


        public static void AddValue(char input)
        {
            if (current.Text != "" && current.Text != null)
            {
                if (current.Text.Last().Equals(')'))
                {
                    current.Text += " * " + input;
                }
                else
                {
                    current.Text += input;
                }
            }
            else
            {
                current.Text += input;
            }
            operation = 't';
        }

        public static void MakeCurrentNumberNegOrPos()
        {
            if (current.Text == "" || current.Text == null || current.Text.Last() == ' ')
            {
                current.Text += "-";
            }
            else
            {
                string[] input = current.Text.Split(" ");
                Stack<double> values = new Stack<double>();
                foreach (string s in input)
                {
                    try
                    {
                        values.Push(Convert.ToDouble(s));
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                }
                double newNumber = values.Pop() * -1;
                if (newNumber * -1 > 0)
                {
                    current.Text = current.Text.Substring(0, current.Text.Length - newNumber.ToString().Length + 1);
                }
                else
                {
                    current.Text = current.Text.Substring(0, current.Text.Length - newNumber.ToString().Length - 1);
                }
                current.Text += newNumber.ToString();
            }
        }

        public static void Clear()
        {
            current.Text = "";
            outputValue.Text = "";
            operation = 's';
        }
        public static void AddOp(char c)
        {
            if (operation == 't')
            {
                switch (c)
                {
                    case '+':
                        current.Text += " + ";
                        operation = '+';
                        break;
                    case '/':
                        current.Text += " / ";
                        operation = '/';
                        break;
                    case '-':
                        current.Text += " - ";
                        operation = '-';
                        break;
                    case '*':
                        current.Text += " * ";
                        operation = '*';
                        break;
                    case 'm':
                        current.Text += " m ";
                        operation = 'm';
                        break;
                    case '÷':
                        current.Text += "÷";
                        operation = 't';
                        break;
                }
            }
        }

        public static void Remove()
        {
            if (current.Text != "" && current.Text != null)
            {
                if (current.Text.Last() == ' ')
                {
                    current.Text = current.Text.Substring(0, current.Text.Length - 3);
                    operation = 't';
                }
                else
                {
                    current.Text = current.Text.Substring(0, current.Text.Length - 1);
                }
            }
        }

        public static void AddBracket()
        {
            int openBrackets = 0;
            int closedBrackets = 0;


            if (current.Text != "" && current.Text != null)
            {
                foreach (char c in current.Text)
                {
                    if (c == '(')
                    {
                        openBrackets++;
                    }
                    else if (c == ')')
                    {
                        closedBrackets++;
                    }
                }
                if (openBrackets == closedBrackets)
                {
                    if (current.Text.Last() == ' ')
                    {
                        current.Text += " ( ";
                    }
                    else
                    {
                        current.Text += " * ( ";
                    }
                }
                else
                {
                    if (current.Text[current.Text.Length - 2] != '(')
                    {
                        current.Text += " ( ";
                    }
                    else if (IsOp())
                    {
                        current.Text += " ) ";
                    }
                }
            }
            else
            {
                current.Text += " ( ";
            }
        }

        public static bool IsOp()
        {
            try
            {
                Convert.ToDouble(current.Text[current.Text.Length - 2]);
                return false;
            }
            catch (InvalidCastException)
            {
                return true;
            }
        }

        public static void Equals()
        {
            if (current.Text != "" && current.Text != null)
            {
                if (current.Text.EndsWith(' '))
                {
                    current.Text = current.Text.Substring(0, current.Text.Length - 3);
                    operation = 't';
                }
                else if (current.Text.EndsWith('('))
                {
                    current.Text = current.Text.Substring(0, current.Text.Length - 1);
                    operation = 't';
                }

                System.Data.DataTable table = new System.Data.DataTable();
                int i = 0;
                double v = 0;

                while (i == 0)
                {
                    try
                    {
                        v = Convert.ToDouble(table.Compute(current.Text, String.Empty));
                        i++;
                    }
                    catch (System.Data.SyntaxErrorException exc)
                    {
                        if (exc.Message.Contains('-') || exc.Message.Contains('+') || exc.Message.Contains('/') || exc.Message.Contains('*'))
                        {
                            current.Text = current.Text.Substring(0, current.Text.Length - 3);
                        }
                        else if (exc.Message.Contains("parenth"))
                        {
                            current.Text += ")";
                        }
                        else if (exc.Message.Contains("'m'"))
                        {
                            current.Text = current.Text.Replace('m', '%');
                        }
                        else if (exc.Message.Contains('÷'))
                        {
                            int endI = current.Text.IndexOf('÷');
                            current.Text = current.Text.Remove(endI, 1);
                            endI--;
                            int startI = endI;
                            while (current.Text[startI] != ' ' && startI != 0)
                            {
                                startI--;
                            }

                            double temp = Convert.ToDouble(current.Text.Substring(startI, endI - startI + 1));
                            temp = temp / 100;
                            current.Text = current.Text.Remove(startI, endI - startI + 1);
                            current.Text = current.Text.Insert(startI, temp.ToString());

                        }
                        else
                        {
                            current.Text = current.Text.Replace(',', '.');
                        }
                    }

                }
                outputValue.Text = current.Text;
                current.Text = (v.ToString());
            }
        }
    }
}