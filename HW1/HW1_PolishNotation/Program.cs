#region

using HW1_PolishNotation;

#endregion

Console.WriteLine(Calculate(Console.ReadLine()));

double Calculate(string input)
{
    var output = GetExpression(input);
    Console.WriteLine(output);
    var result = Counting(output);
    return result;
}

byte GetPriority(char s)
{
    switch (s)
    {
        case '(': return 0;
        case ')': return 1;
        case '+': return 2;
        case '-': return 3;
        case '*': return 4;
        case '/': return 4;
        case '^': return 5;
        default: return 6;
    }
}

bool IsOperator(char с)
{
    if ("+-/*^()".IndexOf(с) != -1)
        return true;
    return false;
}

bool IsDelimeter(char c)
{
    if (" =".IndexOf(c) != -1)
        return true;
    return false;
}

string GetExpression(string input)
{
    var output = string.Empty;
    var operStack = new MyStack<char>(input.Length);

    for (var i = 0; i < input.Length; i++)
    {
        if (IsDelimeter(input[i]))
            continue;

        if (char.IsDigit(input[i]))
        {
            while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
            {
                output += input[i];
                i++;

                if (i == input.Length) break;
            }

            output += " ";
            i--;
        }

        if (IsOperator(input[i]))
        {
            if (input[i] == '(')
            {
                operStack.Push(input[i]);
            }
            else if (input[i] == ')')
            {
                var s = operStack.Pop();

                while (s != '(')
                {
                    output += s.ToString() + ' ';
                    s = operStack.Pop();
                }
            }
            else
            {
                if (operStack.Count > 0)
                    if (GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                        output += operStack.Pop() + " ";

                operStack.Push(char.Parse(input[i].ToString()));
            }
        }
    }

    while (operStack.Count > 0)
        output += operStack.Pop() + " ";

    return output;
}

double Counting(string input)
{
    double result = 0;
    var temp = new MyStack<double>(input.Length);

    for (var i = 0; i < input.Length; i++)
        if (char.IsDigit(input[i]))
        {
            var a = string.Empty;

            while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
            {
                a += input[i];
                i++;
                if (i == input.Length) break;
            }

            temp.Push(double.Parse(a));
            i--;
        }
        else if (IsOperator(input[i]))
        {
            var a = temp.Pop();
            var b = temp.Pop();

            switch (input[i])
            {
                case '+':
                    result = b + a;
                    break;
                case '-':
                    result = b - a;
                    break;
                case '*':
                    result = b * a;
                    break;
                case '/':
                    result = b / a;
                    break;
                case '^':
                    result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString());
                    break;
            }

            temp.Push(result);
        }

    return temp.Peek();
}