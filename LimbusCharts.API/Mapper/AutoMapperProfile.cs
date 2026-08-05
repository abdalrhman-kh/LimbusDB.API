using AutoMapper;
using LimbusCharts.API.Models.Domain;
using LimbusCharts.API.Models.DTO;
using LimbusCharts.API.Models.DTO.CreateRequests;
using LimbusCharts.API.Models.DTO.EditRequests;

namespace LimbusCharts.API.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Identity, IdentityCreateRequestDTO>().ReverseMap();
            CreateMap<IdentityDTO, Identity>();
            CreateMap<Identity, IdentityDTO>().ForMember(des => des.StatusEffectIds, opt => opt.MapFrom(src => src.StatusEffects.Select(i => i.Id).ToList())).
                ForMember(des => des.TraitKeyWordIds, opt => opt.MapFrom(src => src.TraitKeywords.Select(i => i.Id).ToList()))
                .ForMember(des => des.StaggerThresholdIds, opt => opt.MapFrom(src => src.StaggerThresholds.Select(i => i.Id).ToList()))
                .ForMember(des => des.IdentityUpTieIds, opt => opt.MapFrom(src => src.IdentityUpTies.Select(i => i.IdentityUpTieId).ToList()));
            CreateMap<Identity, IdentityEditRequestDTO>().ReverseMap();


            CreateMap<StatusEffect, StatusEffectCreateRequestDTO>().ReverseMap();
            CreateMap<StatusEffectDTO, StatusEffect>();
            CreateMap<StatusEffect, StatusEffectEditRequestDTO>().ReverseMap();
            CreateMap<StatusEffect, StatusEffectDTO>();


            CreateMap<TraitKeywordCreateRequestDTO, TraitKeyword>();
            CreateMap<TraitKeyword, TraitKeywordDTO>().ForMember(des => des.IdentityIds, opt => opt.MapFrom(src => src.Identities.Select(i => i.Id).ToList()));
            CreateMap<TraitKeywordEditRequestDTO, TraitKeyword>();

            CreateMap<StaggerThresholdCreateRequestDTO, StaggerThreshold>();
            CreateMap<StaggerThreshold, StaggerThresholdDTO>().ForMember(des => des.identityIds, opt => opt.MapFrom(src => src.identities.Select(i => i.Id).ToList()));
            CreateMap<StaggerThresholdEditRequestDTO, StaggerThreshold>();

            CreateMap<SinAffinityCreateRequestDTO, SinAffinity>();
            CreateMap<SinAffinity, SinAffinityDTO>();
            CreateMap<SinAffinityEditRequestDTO, SinAffinity>();

            CreateMap<SkillsCreateRequestDTO, Skills>();
            CreateMap<Skills, SkillsDTO>().ForMember(des => des.statusEffectIds, opt => opt.MapFrom(src => src.StatusEffects.Select(i => i.Id).ToList()));
            CreateMap<SkillsEditRequestDTO, Skills>();

            CreateMap<SinAffinityCoutCreateRequestDTO, SinAffinityCount>();
            CreateMap<SinAffinityCount, SinAffinityCountDTO>().ForMember(des => des.PassiveIds, opt => opt.MapFrom(src => src.Passives.Select(i => i.Id).ToList()));
            CreateMap<SinAffinityCountEditRequestDTO, SinAffinityCount>();

            CreateMap<PassivesCreateRequestDTO, Passives>();
            CreateMap<Passives, PassivesDTO>().ForMember(des => des.statusEffectIds, opt => opt.MapFrom(src => src.statusEffects.Select(i => i.Id).ToList())).
                ForMember(des => des.SinAffinityCountIds, opt => opt.MapFrom(src => src.SinAffinityCounts.Select(i => i.Id).ToList()));
            CreateMap<PassivesEditRequestDTO, Passives>();

            CreateMap<SinnerCreateRequestDTO, Sinner>().ReverseMap();
            CreateMap<Sinner, SinnerDTO>().ReverseMap();
            CreateMap<SinnerEditRequestDTO, Sinner>().ReverseMap();

            CreateMap<RariryCreateRequestDTO, Rarity>().ReverseMap();
            CreateMap<Rarity, RarityDTO>().ReverseMap();
            CreateMap<RarityEditRequestDTO, Rarity>().ReverseMap();

            CreateMap<IdentityUpTieCreateRequestDTO, IdentityUpTie>().ReverseMap();
            CreateMap<IdentityUpTie, IdentityUpTieDTO>().ReverseMap();
            CreateMap<IdentityUpTieEditRequestDTO, IdentityUpTie>().ReverseMap();

            CreateMap<UpTieCreateRequestDTO, UpTie>().ReverseMap();
            CreateMap<UpTie, UpTieDTO>().ReverseMap();
            CreateMap<UpTieEditRequestDTO, UpTie>().ReverseMap();

            CreateMap<SeasonCreateRequestdTO, Season>().ReverseMap();
            CreateMap<Season, SeasonDTO>().ReverseMap();
            CreateMap<SeasonEditRequestDTO, Season>().ReverseMap();
        }
    }
}
