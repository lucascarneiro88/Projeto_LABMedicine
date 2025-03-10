﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LABMedicine.CustomValidation;

public class CustomValidation
{
    public sealed class checkStatusAtendimento : ValidationAttribute
    {
        public String AllowStatus { get; set; }

        protected override ValidationResult IsValid(object statusAtendimento, ValidationContext validationContext)
        {
            string[] myarr = AllowStatus.ToString().Split(',');
            if (myarr.Contains(statusAtendimento))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Por favor, informar um status válido! Ex. [" + AllowStatus.ToString() + "]");
            }
        }
    }

    public sealed class checkCPF : ValidationAttribute
    {
        protected override ValidationResult IsValid(object cpf, ValidationContext validationContext)
        {
            if (ValidarCPF(cpf.ToString()))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Por favor, informar um CPF válido, somente números!");
            }
        }
        public static bool ValidarCPF(string cpf)
        {
            // Remove caracteres não numéricos do CPF
            cpf = Regex.Replace(cpf, @"[^\d]", "");

            // Verifica se o CPF possui 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (ex: 111.111.111-11)
            if (new string(cpf[0], 11) == cpf)
                return false;

            // Calcula os dois dígitos verificadores
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int digito1 = 11 - (soma % 11);
            if (digito1 >= 10)
                digito1 = 0;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            int digito2 = 11 - (soma % 11);
            if (digito2 >= 10)
                digito2 = 0;

            // Verifica se os dígitos calculados são iguais aos dígitos informados
            if (digito1 != int.Parse(cpf[9].ToString()) || digito2 != int.Parse(cpf[10].ToString()))
                return false;

            // CPF válido
            return true;
        }
    }
}