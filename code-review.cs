// code review

public void ProcessMacroCommand(string str)
{
    if (string.IsNullOrEmpty(str))
    {
        return;
    }

    var braceExpression = "";
    for (var i = 0; i < str.Length; i++)
    {
        int code = str[i];
        if (code == '{') // found start brace
        {
            for (var j = i + 1; j < str.Length; j++)
            {
                if (str[j] == '}') // found end brace
                {
                    braceExpression = str.Substring(i + 1, j - i - 1);
                    var newCode = KeycodeFromBraceExpression(braceExpression);
                    if (newCode >= 0)
                    {
                        // skip the remainder of the brace expression
                        i = j;

                        code = newCode;
                    }
                    break;
                }
            }
        }

        if (code > 0)
        {
            ProcessKey(code);
        }
    }
}









// Examples:
// ProcessMacroCommand("abc{enter}");  => 0x61 0x62 0x63 0x0d
// ProcessMacroCommand("xyz{tab}123{enter}");    => 0x78 0x79 0x7A 0x09 0x31 0x32 0x33 0x0d
