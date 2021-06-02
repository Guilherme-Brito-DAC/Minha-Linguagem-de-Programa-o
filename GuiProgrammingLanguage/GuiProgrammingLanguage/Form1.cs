using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace GuiProgrammingLanguage
{
    public partial class RootIDE : Form
    {
        Dictionary<string, string> strings = new Dictionary<string, string>();
        Dictionary<string, double> number = new Dictionary<string, double>();
        Dictionary<string, bool> bools = new Dictionary<string, bool>();

        string[] AllVariables = new string[] { };
        public RootIDE()
        {
            InitializeComponent();
            txt_code.Select();
        }
        private void RootIDE_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Execute();
        }

        #region Interpreter
        void Execute()
        {
            // Limpa e reseta as variaveis do sistema
            List<string> list = AllVariables.ToList();
            list.Clear();
            AllVariables = list.ToArray();
            txt_output.Text = "";
            strings.Clear();
            bools.Clear();
            number.Clear();

            //Pega o texto do Editor e divide em cada linha e coloca em uma lista/array
            string[] lines = txt_code.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            
            Interpreter(lines);
        }
        void Interpreter(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                //Verifica se a linha não tem nenhum código ou é vazia, se for vai para a próxima linha
                if (string.IsNullOrEmpty(lines[i]) || string.IsNullOrWhiteSpace(lines[i])) continue;

                #region Algumas operações Matemáticas

                if (lines[i].Contains("++") || lines[i].Contains("--"))
                {
                    string Operation = lines[i].Contains("++") ? "++" : "--"; // Verifica se o usuário está somando ou subtraindo 1

                    string variable = lines[i].Trim().Split(new[] { Operation }, StringSplitOptions.None)[0];   //Pega o nome da variavel que o usuário está tentando operar

                    double value;
                    
                    if (number.ContainsKey(variable) && number.TryGetValue(variable, out value))   // Verifica se essa variavel é numerica
                    {   
                        double varValue = Operation == "++" ? value + 1 : value - 1;
                        number[variable] = varValue;

                        RemoveFromList(variable);

                        AllVariables = AllVariables.Concat(new string[] { variable.Trim() + " %#($#(*%(#@¨$ " + varValue.ToString() }).ToArray();
                    }
                    continue;
                }

                if (lines[i].Contains("+=") || lines[i].Contains("-="))
                {
                    string Operation = lines[i].Contains("+=") ? "+=" : "-=";  

                    string variable = lines[i].Split(new[] { Operation }, StringSplitOptions.None)[0];

                    variable = variable.Trim();

                    double valueToUse;

                    double value;

                    if (double.TryParse(lines[i].Split(new[] { Operation }, StringSplitOptions.None)[1], out valueToUse) && number.ContainsKey(variable) && number.TryGetValue(variable, out value))
                    {
                        double varValue = Operation == "+=" ? value + valueToUse : value - valueToUse;
                        string varname = variable;
                        number[varname] = varValue;

                        RemoveFromList(varname);

                        AllVariables = AllVariables.Concat(new string[] { varname.Trim() + " %#($#(*%(#@¨$ " + varValue.ToString() }).ToArray();
                    }
                    continue;
                }

                #endregion
                
               
                string[] elements = lines[i].Split(' ');

                if (elements[0] == "print")
                {
                    string line = lines[i].Split(new[] { "print" }, StringSplitOptions.None)[1];
                    print(line);
                    continue;
                }

                if (elements[0].ToLower() == "if")
                {
                    int index = 0;

                    if (lines[i + 1].Contains('{')) index = i;

                    int EndIndex = GetEndIndexOfIf(index + 1, lines);
                    int EndIndexOfTheFirstIf = GetEndIndex(index + 1, lines);

                    try
                    {
                        string[] SectionToExecute = new List<string>(lines).GetRange(index, EndIndex - index).ToArray();
                        Cases(SectionToExecute, lines, index, EndIndexOfTheFirstIf);
                    }
                    catch
                    {
                        txt_output.Text += "Erro Linha: " + i;
                    }

                    i += EndIndex;
                    continue;
                }

                if (elements[0].ToLower() == "loop")
                {
                    int index = 0;

                    string condition = lines[i].Replace("loop", "").Trim();

                    if (lines[i + 1].Contains('{')) index = i + 1;

                    int EndIndex = GetEndIndex(index, lines);

                    string[] SectionToExecute = new List<string>(lines).GetRange(index, EndIndex - index).ToArray();

                    Loop(condition, SectionToExecute);

                    i += EndIndex;
                    continue;
                }

                string beforeEqual = lines[i].Split(new[] { '=' }, 1)[0];
                if (!string.IsNullOrEmpty(beforeEqual) && lines[i].Contains('=') && lines[i].IndexOf("var") < lines[i].IndexOf("="))
                {
                    try
                    {
                        CreatingVariables(lines[i]);
                    }
                    catch
                    {
                        txt_output.Text += "Erro Linha " + i + ": " + "Impossível criar variável";
                    }
                    continue;
                }
            }

            txt_memory.Text = "";
            foreach (string variable in AllVariables)
            {
                txt_memory.Text += variable.Split(new string[] { "%#($#(*%(#@¨$" }, StringSplitOptions.None)[0]
                    .ToString() + " = " +
                    variable.Split(new string[] { "%#($#(*%(#@¨$" }, StringSplitOptions.None)[1]
                    .ToString() + "\n";
            }
        }
        int GetEndIndexOfIf(int InitialIndex, string[] lines)
        {
            int EndIndex = GetEndIndex(InitialIndex, lines);

            for (int y = InitialIndex + 1; y < lines.Length; y++)
            {
                if (lines[y].Split(' ')[0] == "else" && lines[y + 1].Trim() == "{")
                {
                    EndIndex = GetEndIndex(y + 2, lines);
                    continue;
                }
            }

            return EndIndex;
        }
        int GetEndIndex(int InitialIndex, string[] lines)
        {
            int EndIndex = 0;
            int BracketRight = 1;

            for (int y = InitialIndex + 1; y < lines.Length; y++)
            {
                if (lines[y].Contains('{')) BracketRight++;

                if (lines[y].Contains('}'))
                {
                    if (BracketRight == 1)
                    {
                        EndIndex = y;
                        break;
                    }
                    BracketRight--;
                    continue;
                }
            }
            return EndIndex;
        }

        #endregion

        #region Variaveis
        void CreatingVariables(string line)
        {
            string var = line.Split(new[] { '=' }, 2)[0].Trim();
            string varname = var.Split(' ')[1];
            string varValue = line.Split(new[] { '=' }, 2)[1].Trim();


            if (varValue.ToLower() == "false" || varValue.ToLower() == "true")
            {
                bool Value = Boolean.Parse(varValue.ToLower());
                CreatingBools(varname, Value);
                return;
            }

            if (varValue.StartsWith("\"") && varValue.EndsWith("\""))
            {
                if (strings.ContainsKey(varname))
                {
                    strings[varname] = varValue;

                    RemoveFromList(varname);

                    AllVariables = AllVariables.Concat(new string[] { varname.Trim() + " %#($#(*%(#@¨$ " + varValue.ToString() }).ToArray();
                    return;
                }

                if (!number.ContainsKey(varname) && !bools.ContainsKey(varname) && !strings.ContainsKey(varname))
                {
                    strings.Add(varname, varValue);
                    AllVariables = AllVariables
                        .Concat(new string[] { varname.Trim() + " %#($#(*%(#@¨$ " + varValue.ToString() })
                        .ToArray();
                }

                return;
            }

            double valueNumber;
            varValue = varValue.Replace(".", ",");
            if (Double.TryParse(varValue, out valueNumber))
            {
                CreatingNumbers(varname, valueNumber);
                return;
            }

            Regex Eval = new Regex(@"/([\w]+[\*\+\-\/\%][\w])+/g");
            if (!string.IsNullOrEmpty(Eval.Matches(varValue).ToString()))
            {
                string[] types =
                {
                "+",
                "-",
                "/",
                "%",
                "*",
            };

                foreach (string type in types)
                {
                    if (varValue.LastIndexOf(type) == varValue.Length - 1) return;
                    if (varValue.IndexOf(type) == 0) return;
                }

                string[] sections = varValue.Split(new[] { "+", "-", "/", "%", "*", }, StringSplitOptions.None);
                foreach (string value in sections)
                {
                    if (number.ContainsKey(value.Trim()))
                    {
                        StringBuilder builder = new StringBuilder(varValue);
                        builder.Replace(value.Trim(), number[value.Trim()].ToString());
                        varValue = builder.ToString();
                    }
                }
                DataTable dt = new DataTable();
                int NumericalExpressions = (int)dt.Compute(varValue, "");

                CreatingNumbers(varname, Convert.ToDouble(NumericalExpressions));
                return;
            }
        }
        void CreatingBools(string varname, bool Value)
        {
            if (bools.ContainsKey(varname))
            {
                bools[varname] = Value;

                RemoveFromList(varname);

                AllVariables = AllVariables.Concat(new string[] { varname.Trim() + " %#($#(*%(#@¨$ " + Value.ToString().Trim() }).ToArray();
                return;
            }

            if (!number.ContainsKey(varname) && !bools.ContainsKey(varname) && !strings.ContainsKey(varname))
            {
                bools.Add(varname, Value);
                AllVariables = AllVariables.Concat(new string[] { varname.Trim() + " %#($#(*%(#@¨$ " + Value.ToString().Trim() }).ToArray();
                return;
            }
        }

        void CreatingNumbers(string varname, double valueNumber)
        {
            if (number.ContainsKey(varname))
            {
                number[varname] = valueNumber;

                RemoveFromList(varname);

                AllVariables = AllVariables.Concat(new string[] { varname.Trim() + " %#($#(*%(#@¨$ " + valueNumber.ToString().Trim() }).ToArray();
                return;
            }

            if (!number.ContainsKey(varname) && !bools.ContainsKey(varname) && !strings.ContainsKey(varname))
            {
                number.Add(varname, valueNumber);
                AllVariables = AllVariables.Concat(new string[] { varname.Trim() + " %#($#(*%(#@¨$ " + valueNumber.ToString().Trim() }).ToArray();
            }
            return;
        }

        void RemoveFromList(string varname)
        {
            List<string> VariablesList = AllVariables.ToList();
            int VarIndexToDelete = VariablesList.FindIndex((x) => x.ToString().Split(new[] { "%#($#(*%(#@¨$" }, StringSplitOptions.None)[0].Trim() == varname);
            VariablesList.RemoveAt(VarIndexToDelete);
            AllVariables = VariablesList.ToArray();
        }
        #endregion

        #region Imprimindo
        void print(string line)
        {
            if (line.Trim().StartsWith("\"") && line.Trim().EndsWith("\""))
            {
                txt_output.Text += line + "\n";
                return;
            }
            line = line.Replace(" ", "");
            if (number.ContainsKey(line))
            {
                txt_output.Text += number[line].ToString() + "\n";
                return;
            }
            else if (bools.ContainsKey(line))
            {
                txt_output.Text += bools[line].ToString() + "\n";
                return;
            }
            else if (strings.ContainsKey(line))
            {
                txt_output.Text += strings[line].Replace("\"", "").ToString() + "\n";
                return;
            }

            Regex Eval = new Regex(@"/([\w]+[\*\+\-\/\%][\w])+/g");
            if (!string.IsNullOrEmpty(Eval.Matches(line).ToString()))
            {
                string[] sections = line.Split(new[] { "+", "-", "/", "%", "*", }, StringSplitOptions.None);
                foreach (string value in sections)
                {
                    if (number.ContainsKey(value.Trim()))
                    {
                        StringBuilder builder = new StringBuilder(line);
                        builder.Replace(value.Trim(), number[value.Trim()].ToString());
                        line = builder.ToString();
                    }
                }
                DataTable dt = new DataTable();
                try
                {
                    int NumericalExpressions = (int)dt.Compute(line, "");
                    txt_output.Text += NumericalExpressions.ToString() + "\n";
                }
                catch
                {
                    txt_output.Text += "Erro : Output (print) error , Caractere inválido";
                }

                return;
            }
        }

        #endregion

        #region Condição/if

        void Cases(string[] SectionToExecute, string[] lines, int Index, int EndIndexOfTheFirstIf)
        {
            string[] ConditionsOrCases = { };
            string[][] Sections = { };
            string[][] ElseSections = { };

            string y = lines[Index].Replace("if", "").Replace(" ", "");
            ConditionsOrCases = ConcantConditions(ConditionsOrCases, y);
            Sections = ConcatSections(Sections, 0, lines);

            for (int i = Index; i < SectionToExecute.Length; i++)
            {
                if (lines[i].ToLower().Contains("else") && lines[i].ToLower().Contains("if") && lines[i + 1].Replace(" ", "") == "{" && lines[i - 1].Replace(" ", "") == "}" && i > EndIndexOfTheFirstIf)
                {
                    string x = lines[i].Replace("else", "").Replace("if", "").Replace(" ", "");
                    ConditionsOrCases = ConcantConditions(ConditionsOrCases, x);

                    Sections = ConcatSections(Sections, i, lines);
                    continue;
                }
                if (lines[i].Replace(" ", "").ToLower() == "else" && lines[i + 1].Replace(" ", "") == "{" && lines[i - 1].Replace(" ", "") == "}" && i > EndIndexOfTheFirstIf)
                {
                    ElseSections = ConcatSections(ElseSections, i, lines);
                    break;
                }
            }
            for (int i = 0; i < ConditionsOrCases.Length; i++)
            {
                bool IsTrueOrFalse = Conditions(ConditionsOrCases[i]);

                if (IsTrueOrFalse)
                {
                    Interpreter(Sections[i]);
                    return;
                }
            }

            if (ElseSections.Length != 0) Interpreter(ElseSections[0]);
        }

        string[] ConcantConditions(string[] ConditionsOrCases, string x)
        {
            List<string> ConditionList = new List<string>(ConditionsOrCases);
            ConditionList.Add(x);
            ConditionsOrCases = ConditionList.ToArray();
            return ConditionsOrCases;
        }
        string[][] ConcatSections(string[][] Sections, int i, string[] lines)
        {
            int Index = i + 2;
            int EndIndex = GetEndIndex(Index, lines);

            String[] Else = new List<string>(lines).GetRange(Index, EndIndex - Index).ToArray();
            List<string[]> SectionsList = new List<string[]>(Sections);

            SectionsList.Add(Else);
            Sections = SectionsList.ToArray();

            return Sections;
        }
        bool Conditions(string Condition)
        {
            string[] variables = Condition.Replace(" ", "").Split(new[] { "==", "<", ">", "<=", ">=" }, StringSplitOptions.None);

            foreach (string variable in variables)
            {
                if (number.ContainsKey(variable))
                {
                    Condition = Condition.Replace(variable, number[variable].ToString());
                    continue;
                }
                if (strings.ContainsKey(variable.Trim()))
                {
                    Condition = Condition.Replace(variable, strings[variable]);
                    continue;
                }
                if (bools.ContainsKey(variable))
                {
                    Condition = Condition.Replace(variable, bools[variable].ToString());
                    continue;
                }
                if (double.TryParse(variable, out double Value))
                {
                    Condition = Condition.Replace(variable, Value.ToString());
                    continue;
                }
            }

            if (Condition.Contains("==") || Condition.Contains("!="))
            {
                string Condition1 = Condition.Split(new[] { "==", "!=" }, StringSplitOptions.None)[0];
                string Condition2 = Condition.Split(new[] { "==", "!=" }, StringSplitOptions.None)[1];

                bool IsEqual;
                IsEqual = Condition.Contains("==") ? Condition1.Trim() == Condition2.Trim() ? true : false : Condition1.Trim() != Condition2.Trim() ? false : true;

                txt_output.Text = IsEqual.ToString();
                return IsEqual;
            }
            bool Expressions = false;
            try
            {
                DataTable dt = new DataTable();
                Expressions = (bool)dt.Compute(Condition, "");
            }
            catch
            {
                txt_output.Text += "Erro Condição inválida";

            }
            return Expressions;

        }

        #endregion

        #region Ciclos/Loops

        void Loop(string condition, string[] lines)
        {
            int Times = 0;
            int TimesToRun = 0;
            condition = condition.Trim();

            if (int.TryParse(condition, out Times))
            {
                TimesToRun = Times;
                For(condition, lines, TimesToRun);
                return;
            }
            if (number.ContainsKey(condition))
            {
                TimesToRun = (int)Math.Round(number[condition]);
                For(condition, lines, TimesToRun);
                return;
            }

            bool Continue = bools.ContainsKey(condition) ? Continue = bools[condition] : Conditions(condition);
            While(Continue, lines, condition);
        }

        void For(string condition, string[] lines, int TimesToRun)
        {
            for (int x = 0; x < TimesToRun; x++)
            {
                if (number.ContainsKey(condition)) TimesToRun = (int)Math.Round(number[condition]);
                Interpreter(lines);
            }
        }

        void While(bool Continue, string[] lines, string condition)
        {
            while (Continue)
            {
                Interpreter(lines);
                Continue = bools.ContainsKey(condition) ? Continue = bools[condition] : Conditions(condition);
            }
        }

        #endregion

        #region Janela && Formatações

        System.Drawing.Color Red = System.Drawing.ColorTranslator.FromHtml("#a73a28");
        System.Drawing.Color Blue = System.Drawing.ColorTranslator.FromHtml("#547574");
        System.Drawing.Color Green = System.Drawing.ColorTranslator.FromHtml("#6d995e");
        System.Drawing.Color Pink = System.Drawing.ColorTranslator.FromHtml("#cc7e8f");
        private void txt_code_TextChanged_1(object sender, EventArgs e)
        {
            string[] lines = txt_code.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            txt_linecount.Text = "";
            for (int i = 0; i < lines.Length; i++)
            {
                txt_linecount.Text += i + "\n";
            }


            string[] finds = {
                "print",
                "loop",
                "if",
                "else if",
                "else",
                "var",
            };

            foreach (string find in finds)
            {
                if (txt_code.Text.Contains(find))
                {
                    var matchString = Regex.Escape(find);
                    foreach (Match match in Regex.Matches(txt_code.Text, matchString))
                    {
                        txt_code.Select(match.Index, find.Length);
                        txt_code.SelectionColor = Red;
                        txt_code.Select(txt_code.TextLength, 0);
                        txt_code.SelectionColor = txt_code.ForeColor;
                    };
                }
            }

            string[] Symbols = {
                "=",
                "==",
                "!=",
                "<",
                ">",
                ">=",
                "<=",
                "+",
                "-",
                "*",
                "/",
            };

            foreach (string Symbol in Symbols)
            {
                if (txt_code.Text.Contains(Symbol))
                {
                    var matchString = Regex.Escape(Symbol);
                    foreach (Match match in Regex.Matches(txt_code.Text, matchString))
                    {
                        txt_code.Select(match.Index, Symbol.Length);
                        txt_code.SelectionColor = Green;
                        txt_code.Select(txt_code.TextLength, 0);
                        txt_code.SelectionColor = txt_code.ForeColor;
                    };
                }
            }


            string[] States = {
                "true",
                "false",
                "False",
                "True",
                "TRUE",
                "FALSE",
            };

            foreach (string State in States)
            {
                if (txt_code.Text.Contains(State))
                {
                    var matchString = Regex.Escape(State);
                    foreach (Match match in Regex.Matches(txt_code.Text, matchString))
                    {
                        txt_code.Select(match.Index, State.Length);
                        txt_code.SelectionColor = Pink;
                        txt_code.Select(txt_code.TextLength, 0);
                        txt_code.SelectionColor = txt_code.ForeColor;
                    };
                }
            }

            foreach (string Variable in AllVariables)
            {
                string VarName = Variable.Split(new[] { " %#($#(*%(#@¨$ " }, StringSplitOptions.None)[0];
                VarName = VarName.Replace(" ", "");

                var matchString = Regex.Escape(VarName);
                foreach (Match match in Regex.Matches(txt_code.Text, matchString))
                {
                    txt_code.Select(match.Index, VarName.Length);
                    txt_code.SelectionColor = Blue;
                    txt_code.Select(txt_code.TextLength, 0);
                    txt_code.SelectionColor = txt_code.ForeColor;
                }
            }
        }
        private void btn_saída_Click(object sender, EventArgs e)
        {
            txt_memory.Visible = true;
            txt_output.Visible = false;
        }

        private void btn_memoria_Click(object sender, EventArgs e)
        {
            txt_memory.Visible = false;
            txt_output.Visible = true;
        }

        #endregion

        #region Performance e Memória

        PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

        public string getCurrentCpuUsage()
        {
            return Math.Round(cpuCounter.NextValue()) + "%";
        }

        public string getAvailableRAM()
        {
            return Math.Round(ramCounter.NextValue()) + "MB";
        }
        public void Performance()
        {
            lbl_performance.Text = "CPU "+ getCurrentCpuUsage() + "       " + "MEM " + getAvailableRAM();
        }

        #endregion   
    }
}
