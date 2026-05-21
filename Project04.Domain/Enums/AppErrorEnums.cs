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
        ExpiredToken = 4000029,
        InvalidRegexFormat = 4000030,

        #endregion

        #region 401

        Unauthorized = 4010000,
        UnauthorizedInvalidEmailOrPassword = 4010001,
        UnauthorizedUnauthorizedTechnicalUser = 4010002,
        UnauthorizedInvalidAccessToken = 4010003,
        UnauthorizedUserNotFound = 4010004,

        #endregion

        #region 403

        Forbidden = 4030000,
        ForbiddenAccessTokenExpired = 4030001,
        ForbiddenAccessTokenNotFound = 4030002,
        ForbiddenAccountInactive = 4030003,
        ForbiddenInvalidAccessToken = 4030004,

        #endregion

        #region 404

        NotFound = 4040000,
        NotFoundEntity = 40400001,
        NotFoundUser = 4040002,
        NotFoundAccessToken = 4040003,
        NotFoundBudget = 4040004,

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
