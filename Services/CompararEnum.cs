using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistenciaTecnicaApi.Data.Enums;

namespace AssistenciaTecnicaApi.Services;

public class CompararEnum
{
    public static bool CompareStringComEnum(string status)
    {
        foreach (StatusEnum enumValue in Enum.GetValues(typeof(StatusEnum)))
        {
            if (status.Equals(enumValue.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return true; // A string corresponde a um valor no enum
            }
        }
        
        return false; // A string não corresponde a nenhum valor no enum
        
    }
}