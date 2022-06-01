// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;

namespace TestISWithIdentity.Pages.Login
{
    public class InputModel
    {
        [Display(Name = "��� ������������")]
        [Required(ErrorMessage = "������� ��� ������������")]
        public string Username { get; set; }

        [Required(ErrorMessage = "������� ������")]
        [Display(Name = "������")]
        public string Password { get; set; }

        public bool RememberLogin { get; set; }

        public string ReturnUrl { get; set; }

        public string Button { get; set; }
    }
}