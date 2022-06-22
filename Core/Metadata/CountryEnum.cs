namespace Core.Metadata;

public enum CountryEnum
{
    AD,
    AE,
    AF,
    AG,
    AI,
    AL,
    AM,
    AN,
    AO,
    AQ,
    AR,
    AS,
    AT,
    AU,
    AW,
    AX,
    AZ,
    BA,
    BB,
    BD,
    BE,
    BF,
    BG,
    BH,
    BI,
    BJ,
    BL,
    BM,
    BN,
    BO,
    BQ,
    BR,
    BS,
    BT,
    BV,
    BW,
    BY,
    BZ,
    CA,
    CC,
    CD,
    CF,
    CG,
    CH,
    CI,
    CK,
    CL,
    CM,
    CN,
    CO,
    CR,
    CU,
    CV,
    CW,
    CX,
    CY,
    CZ,
    DE,
    DJ,
    DK,
    DM,
    DO,
    DZ,
    EC,
    EE,
    EG,
    EH,
    ER,
    ES,
    ET,
    FI,
    FJ,
    FK,
    FM,
    FO,
    FR,
    GA,
    GB,
    GD,
    GE,
    GF,
    GG,
    GH,
    GI,
    GL,
    GM,
    GN,
    GP,
    GQ,
    GR,
    GS,
    GT,
    GU,
    GW,
    GY,
    HK,
    HM,
    HN,
    HR,
    HT,
    HU,
    ID,
    IE,
    IL,
    IM,
    IN,
    IO,
    IQ,
    IR,
    IS,
    IT,
    JE,
    JM,
    JO,
    JP,
    KE,
    KG,
    KH,
    KI,
    KM,
    KN,
    KP,
    KR,
    KW,
    KY,
    KZ,
    LA,
    LB,
    LC,
    LI,
    LK,
    LR,
    LS,
    LT,
    LU,
    LV,
    LY,
    MA,
    MC,
    MD,
    ME,
    MF,
    MG,
    MH,
    MK,
    ML,
    MM,
    MN,
    MO,
    MP,
    MQ,
    MR,
    MS,
    MT,
    MU,
    MV,
    MW,
    MX,
    MY,
    MZ,
    NA,
    NC,
    NE,
    NF,
    NG,
    NI,
    NL,
    NO,
    NP,
    NR,
    NU,
    NZ,
    OM,
    PA,
    PE,
    PF,
    PG,
    PH,
    PK,
    PL,
    PM,
    PN,
    PR,
    PS,
    PT,
    PW,
    PY,
    QA,
    RE,
    RO,
    RS,
    RU,
    RW,
    SA,
    SB,
    SC,
    SD,
    SE,
    SG,
    SH,
    SI,
    SJ,
    SK,
    SL,
    SM,
    SN,
    SO,
    SR,
    SS,
    ST,
    SV,
    SX,
    SY,
    SZ,
    TC,
    TD,
    TF,
    TG,
    TH,
    TJ,
    TK,
    TL,
    TM,
    TN,
    TO,
    TR,
    TT,
    TV,
    TW,
    TZ,
    UA,
    UG,
    UM,
    US,
    UY,
    UZ,
    VA,
    VC,
    VE,
    VG,
    VI,
    VN,
    VU,
    WF,
    WS,
    YE,
    YT,
    ZA,
    ZM,
    ZW
}
//public sealed class Country
//{
//    private readonly int _numeric;
//    private readonly string _name;
//    private readonly string _alpha2;
//    private readonly string _alpha3;
//    private static readonly List<Country?> Countries = new List<Country?>();

//    private Country(string name, string alpha3, int numeric)
//    {
//        _name = name;
//        _alpha3 = alpha3;
//        _numeric = numeric;

//        Countries.Add(this);
//    }
//    public static Country US = new("United States", "111", 1);
//    public static Country Canada = new("Canada", "112", 2);

//    public string GetName()
//    {
//        return _name;
//    }

//    public string GetAlpha3()
//    {
//        return _alpha3;
//    }

//    public int GetNumeric()
//    {
//        return _numeric;
//    }

//    //public int GetCountryCode()
//    //{
//    //    return PhoneNumberUtil.getInstance().getCountryCodeForRegion(name());
//    //}

//    public static Country? GetByCode(string code)
//    {
//        return code.Length switch
//        {
//            2 => GetByAlpha2Code(code),
//            3 => GetByAlpha3Code(code),
//            _ => null
//        };
//    }

//    private static Country? GetByAlpha2Code(string code)
//    {
//        try
//        {
//            return Countries.FirstOrDefault(a => a?._alpha2 == code);
//        }
//        catch (Exception)
//        {
//            return null;
//        }
//    }

//    private static Country? GetByAlpha3Code(string code)
//    {

//        return Countries.FirstOrDefault(a => a._alpha3 == code);
//    }

//    //public static Country getByCode(int code)
//    //{
//    //    return numericMap.get(code);
//    //}

//    //public static Country getBySymbol(String s)
//    //{
//    //    for (Country value : values())
//    //        if (StringUtils.equalsIgnoreCase(s, value.name())) return value;
//    //    return null;
//    //}

//}