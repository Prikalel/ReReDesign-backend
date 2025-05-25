namespace VelikiyPrikalel.ReReDesign.Web.MapperProfiles;

/// <inheritdoc />
public class WebProfile : Profile
{
    /// <summary>
    /// ctor.
    /// </summary>
    public WebProfile()
    {
        CreateMap<DtfUserApplication, DtfUserDto>();
        CreateMap<GetReactionsResponseApplication, GetReactionsResponseDto>();
        CreateMap<ReactionsResultApplication, ReactionsResultDto>();
        CreateMap<UserReactionApplication, UserReactionDto>();
    }
}
