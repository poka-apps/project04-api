namespace Project04.Domain.Enums
{
    public enum AppErrorEnums
    {
        Unknow = 0000000,

        #region 400

        BadRequest = 4000000,

        ArgumentNullPassed = 4000001,

        InvalidEmailFormat = 4000002,

        ArgumentEmptyPassed = 4000004,

        MissingPasswordAccess = 4000005,

        InvalidLength = 4000006,

        InvalidValue = 4000007,

        InvalidRefreshToken = 4000008,

        NegativeValue = 4000009,

        AtLeastOneParameterExpected = 4000010,

        InvalidParseObjectId = 4000011,

        EnumValueNotFound = 4000012,

        InvalidOldPassword = 4000013,

        InvalidDatePeriod = 4000014,

        ValueRequired = 4000015,

        InvalidCast = 4000016,

        InvalidLegalAge = 4000017,

        InvalidUserName = 4000018,

        CodeExpiredOrInValid = 4000019,

        InvalidValueFormat = 4000023,

        MissingValue = 4000020,

        InvalidValueExpected = 4000028,

        #endregion

        #region 401

        [Description("Unauthorized")]
        Unauthorized = 4010000,

        [Description("Invalid email or password.")]
        InvalidEmailOrPassword = 4010001,

        [Description("Technical user not authorized")]
        UnauthorizedTechnicalUser = 4010002,

        #endregion

        #region 403

        [Description("Forbidden")]
        Forbidden = 4030000,

        [Description("Access token is expired.")]
        ForbiddenAccessTokenExpired = 4030001,

        [Description("Access token is not valid.")]
        ForbiddenAccessTokenNotFound = 4030002,

        [Description("Account inactive")]
        ForbiddenAccountInactive = 4030003,

        #endregion

        #region 404

        [Description("Not found")]
        NotFound = 4040000,

        [Description("Entity not found in database.")]
        EntityNotFound = 40400002,

        [Description("User not found")]
        UserNotFound = 4040003,

        [Description("Channel not found")]
        ChannelNotFound = 4040004,

        [Description("Access token not found")]
        AccessTokenNotFound = 4040005,

        [Description("Post not found")]
        PostNotFound = 4040006,

        [Description("Resource not found")]
        ResourceNotFound = 4040007,

        [Description("Tag not found")]
        TagNotFound = 4040008,

        #endregion

        #region 409

        Conflict = 4090000,
        ConflictUserEmailTaken = 4090001,
        InvalidRefreshTokenExpired = 4090002,
        InvalidRefreshTokenSecurityAlgorithm = 4090003,
        ValueLowerOrEqualZeroPassed = 4090004,
        NotUniqueValue = 4090005,
        LoginProviderAlreadyExist = 4090006,
        ConflictUserNameTaken = 4090007,
        ConflictRootUserAlreadyExist = 4090009,
        ValueLowerOrEqual = 4090010,

        #endregion

        #region 500

        [Description("Internal server error")]
        InternalServerError = 5000000,

        #endregion

        #region 501

        [Description("Not implemented")]
        NotImplemented = 5010000

        #endregion
    }
}
