namespace InterfaceSegregationIdentityAfter.Contracts
{
    interface IEmailValidation
    {
        bool RequireUniqueEmail { get; set; }

        int MinRequiredPasswordLength { get; set; }

        int MaxRequiredPasswordLength { get; set; }
    }
}
