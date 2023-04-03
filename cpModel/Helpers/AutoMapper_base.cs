using AutoMapper;
using cpModel.Dtos;
using cpModel.Dtos.CloneDto;
using cpModel.Dtos.Desktop;
using cpModel.Dtos.Export;
using cpModel.Dtos.Lookup;
using cpModel.Dtos.Report;
using cpModel.Dtos.Template;
using cpModel.Enums;
using cpModel.Models;
using DevExpress.XtraRichEdit.Model;
using DevExpress.XtraPrinting;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace cpModel.Helpers
{
    public class AutoMapper_base : Profile
    {
        bool IsApi = cpShared.UserContext.Platform == cpShared.PlatformEnum.API;
        bool IsDesktop = cpShared.UserContext.Platform == cpShared.PlatformEnum.Desktop_sql || cpShared.UserContext.Platform == cpShared.PlatformEnum.Desktop_ce;
        bool IsCe = cpShared.UserContext.Platform == cpShared.PlatformEnum.Desktop_ce;
        public AutoMapper_base()
        {
            CreateMap<Approval, ApprovalBasicLinkDto>();
            CreateMap<Approval, ApprovalListStatuserDto>()
                .ForMember(dest => dest.StatusLastStep, opt => opt.MapFrom(src => src.CloseOutDate != null ? "Closed Out" :
                    src.Workflow.StatusLastStep)).IncludeAllDerived()
                .ForMember(dest => dest.DateLastStep, opt => opt.MapFrom(src => src.Workflow.DateLastStep)).IncludeAllDerived()
                .ForMember(dest => dest.ActionDate, opt => opt.MapFrom(src => src.CloseOutDate != null || src.Workflow.ActionDate == null ?
                    (DateTime?)null : src.Workflow.ActionDate)).IncludeAllDerived()
                .ForMember(dest => dest.IsLatestStepAlert, opt => opt.MapFrom(src => src.Workflow.IsLatestStepAlert)).IncludeAllDerived()
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.CloseOutDate != null ||
                    src.DateDirectlyApproved != null ||
                    (src.Workflow.IsCompleted ?? false))).IncludeAllDerived()
                .ForMember(dest => dest.IsApprovedToProceed, opt => opt.MapFrom(src => src.Workflow.HasApprovalStep)).IncludeAllDerived()
                .ForMember(dest => dest.LastActionByName, opt => opt.MapFrom(src => src.Workflow.LastActionByName)).IncludeAllDerived()
                .ForMember(dest => dest.LastActionComment, opt => opt.MapFrom(src => src.Workflow.LastActionComment)).IncludeAllDerived()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                    src.CloseOutDate != null ? "Closed Out" :
                    (src.Workflow.IsCompleted ?? false) ? src.Workflow.StatusLastStep :
                    src.DateDirectlyApproved != null ? (src.PurchaseOrderLinkId != null ? "Directly Approved" : "Manually Approved") :
                    src.Workflow.StatusLastStep ?? "Not started"
                    )).IncludeAllDerived()
                .ForMember(dest => dest.DateLastStatus, opt => opt.MapFrom(src =>
                    src.CloseOutDate != null ? src.CloseOutDate :
                    (src.Workflow.IsCompleted ?? false) ? src.Workflow.DateLastStep :
                    src.DateDirectlyApproved != null ? src.DateDirectlyApproved :
                    src.Workflow.DateLastStep ?? null
                    )).IncludeAllDerived();
            CreateMap<Approval, ApprovalForNotificationTemplateDto>();

            //This is in both cases resolved in the solution specific mapping - ketp here for records.
            if (!IsApi && !IsDesktop) CreateMap<Approval, ApprovalListDto>()
                .Ignore(x => x.ApprovalTos).IncludeAllDerived()
                .Ignore(x => x.ApprovalCcs).IncludeAllDerived()
                .ForMember(dest => dest.RequestByName, opt => opt.MapFrom(src => src.RequestBy == null ? "" : src.RequestBy.FirstName + " " + src.RequestBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalCategoryName, opt => opt.MapFrom(src => src.ApprovalCategory.Description)).IncludeAllDerived()
                .ForMember(dest => dest.WorkflowName, opt => opt.MapFrom(src => src.ApprovalWorkflow.Description)).IncludeAllDerived()
                .ForMember(dest => dest.IsEmailed, opt => opt.MapFrom(src => src.EmailDate != null || src.ApprovalEmails.Count > 0)).IncludeAllDerived()
                .ForMember(dest => dest.DaysTilDue, opt => opt.MapFrom(src =>
                    src.CloseOutDate != null || src.ActionDate == null ?
                    (int?)null : (src.ActionDate ?? DateTime.UtcNow).Subtract(DateTime.UtcNow).Days)).IncludeAllDerived();

            CreateMap<Approval, ApprovalListExtDto>()
                .ForMember(dest => dest.DirectlyApprovedByName, opt => opt.MapFrom(src => src.DirectlyApprovedBy == null ? "" : src.DirectlyApprovedBy.FirstName + " " + src.DirectlyApprovedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.CloseOutByName, opt => opt.MapFrom(src => src.CloseOutBy == null ? "" : src.CloseOutBy.FirstName + " " + src.CloseOutBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.LogCount, opt => opt.MapFrom(src => src.Workflow.WorkflowLogs.Count)).IncludeAllDerived()
                .ForMember(dest => dest.IsPublished, opt => opt.MapFrom(src => src.PublishDate != null)).IncludeAllDerived()
                .ForMember(dest => dest.ActionCount, opt => opt.MapFrom(src => src.Workflow.WorkflowLogs.Where(x => x.WorkflowAction != null).Count())).IncludeAllDerived();
            CreateMap<Approval, ApprovalDto>();
            CreateMap<ApprovalTo, ApprovalToDto>();
            CreateMap<ApprovalCc, ApprovalCcDto>();
            CreateMap<ApprovalEmail, ApprovalEmailDto>()
                .ForMember(dest => dest.IsPrivate, opt => opt.MapFrom(src => src.WorkflowLog.IsPrivate)).IncludeAllDerived()
                .ForMember(dest => dest.EmailDate, opt => opt.MapFrom(src => src.EmailLog.DateEmailed)).IncludeAllDerived()
                .ForMember(dest => dest.EmailDescription, opt => opt.MapFrom(src => src.EmailLog.Subject)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalSubjectHtml, opt => opt.MapFrom(src => src.Approval.SubjectHtml)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.Approval == null ? null : src.Approval.ApprovalNo)).IncludeAllDerived()
                .ForMember(dest => dest.EmailLogNo, opt => opt.MapFrom(src => src.EmailLog.EmailLogNo)).IncludeAllDerived();
            CreateMap<ApprovalPunchlistItem, ApprovalPunchlistItemDto>()
                .ForMember(dest => dest.PunchlistNo, opt => opt.MapFrom(src => src.PunchlistItem.Punchlist.PunchlistNo)).IncludeAllDerived()
                .ForMember(dest => dest.PunchlistName, opt => opt.MapFrom(src => src.PunchlistItem.Punchlist.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PunchlistItemNo, opt => opt.MapFrom(src => src.PunchlistItem.ItemNo)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalSubjectHtml, opt => opt.MapFrom(src => src.Approval.SubjectHtml)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.Approval == null ? null : src.Approval.ApprovalNo)).IncludeAllDerived();
            CreateMap<ApprovalLot, ApprovalLotDto>()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.Approval.ApprovalNo)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalSubjectHtml, opt => opt.MapFrom(src => src.Approval.SubjectHtml)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber))
                .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description))
                .ForMember(dest => dest.ApprovalIsLatestStepAlert, opt => opt.MapFrom(src => src.Approval.IsLatestStepAlert)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalIsApprovedToProceed, opt => opt.MapFrom(src => src.Approval.IsApprovedToProceed)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalIsCompleted, opt => opt.MapFrom(src => src.Approval.IsCompleted)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalStatus, opt => opt.MapFrom(src => src.Approval.Status)).IncludeAllDerived();
            CreateMap<ApprovalLotItpDetail, ApprovalLotItpDetailDto>()
                .ForMember(dest => dest.ItpRef, opt => opt.MapFrom(src => src.LotItpDetail.LotItp.Itp.Description)).IncludeAllDerived()
                .ForMember(dest => dest.LotNo, opt => opt.MapFrom(src => src.LotItpDetail.LotItp.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.LotItpId, opt => opt.MapFrom(src => src.LotItpDetail.LotItpId)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.Approval.ApprovalNo)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalSubjectHtml, opt => opt.MapFrom(src => src.Approval.SubjectHtml)).IncludeAllDerived();
            CreateMap<Approval, ApprovalStatusInfoDto>();
            CreateMap<Approval, ApprovalStatusInfoDto_Check>()
                .ForMember(dest => dest.ReferenceText, opt => opt.MapFrom(src => src.LotItpDetailLink.ReferenceText)).IncludeAllDerived();
            CreateMap<Approval, ApprovalStatusInfoDto_Ncr>()
                .ForMember(dest => dest.NcrNo, opt => opt.MapFrom(src => src.NcrLink.NcrNo)).IncludeAllDerived();
            if (!IsApi) CreateMap<AreaCode, AreaCodeDto>();
            CreateMap<AtpLot, AtpLotListDto>()
                .ForMember(dest => dest.AtpNo, opt => opt.MapFrom(src => src.Atp.AtpNo)).IncludeAllDerived()
                .ForMember(dest => dest.AtpDescription, opt => opt.MapFrom(src => src.Atp.Description)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber))
                .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description));
            CreateMap<Approval, ApprovalCategoryDto>();
            CreateMap<ApprovalItpDetail, ApprovalItpDetailDto>()
                .ForMember(dest => dest.ItpId, opt => opt.MapFrom(src => src.ItpDetail.ItpId)).IncludeAllDerived()
                .ForMember(dest => dest.ItpDetailDesc, opt => opt.MapFrom(src => src.ItpDetail.Itp.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.Approval.ApprovalNo))
                .ForMember(dest => dest.ApprovalSubjectHtml, opt => opt.MapFrom(src => src.Approval.SubjectHtml))
                .ForMember(dest => dest.FullItpDesc, opt => opt.MapFrom(src => src.ItpDetail.Itp == null ? "" : src.ItpDetail.Itp.ItpDocnumber + ": " + src.ItpDetail.Itp.Description));
            CreateMap<ApprovalNcr, ApprovalNcrDto>()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.Approval.ApprovalNo)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalSubjectHtml, opt => opt.MapFrom(src => src.Approval.SubjectHtml)).IncludeAllDerived()
                .ForMember(dest => dest.NcrNumber, opt => opt.MapFrom(src => src.Ncr.NcrNo)).IncludeAllDerived()
                .ForMember(dest => dest.NcrDescription, opt => opt.MapFrom(src => src.Ncr.Description))
                .ForMember(dest => dest.ApprovalIsLatestStepAlert, opt => opt.MapFrom(src => src.Approval.IsLatestStepAlert)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalIsApprovedToProceed, opt => opt.MapFrom(src => src.Approval.IsApprovedToProceed)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalIsCompleted, opt => opt.MapFrom(src => src.Approval.IsCompleted)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalStatus, opt => opt.MapFrom(src =>
                    src.Approval.Status)).IncludeAllDerived();
            CreateMap<Approval, ApprovalSimpleTemplateDto>();
            CreateMap<Approval, ApprovalTemplateDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ProjectNumber, opt => opt.MapFrom(src => src.Project.ContractNumber)).IncludeAllDerived()
                .ForMember(dest => dest.WorkflowLogsOrdered, opt => opt.MapFrom(src => src.Workflow.WorkflowLogs.OrderByDescending(x => x.LogDate))).IncludeAllDerived();
            CreateMap<ApprovalWorkflow, ApprovalWorkflowDto>()
                .ForMember(dest => dest.ApprovalCategoryName, opt => opt.MapFrom(src => src.ApprovalCategory.Description)).IncludeAllDerived();
            CreateMap<ApprovalWorkflow, ApprovalWorkflowUpdaterDto>()
                .ForMember(dest => dest.ApprovalCategoryName, opt => opt.MapFrom(src => src.ApprovalCategory.Description)).IncludeAllDerived();
            CreateMap<ApprovalWorkflow, ApprovalWorkflowExportDto>().Ignore(x => x.Workflow);
            CreateMap<Atp, AtpListDto>()
                .ForMember(dest => dest.IsApproved, opt => opt.MapFrom(src => !src.AtpLots.Any(x => x.DateApproved == null)))
                .ForMember(dest => dest.SentToName, opt => opt.MapFrom(src => src.SentTo == null ? "" : src.SentTo.FirstName + " " + src.SentTo.LastName))
                .ForMember(dest => dest.RequestedByName, opt => opt.MapFrom(src => src.RequestedBy == null ? "" : src.RequestedBy.FirstName + " " + src.RequestedBy.LastName));
            CreateMap<Atp, AtpDto>();
            CreateMap<Atp, AtpTemplateDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ProjectNumber, opt => opt.MapFrom(src => src.Project.ContractNumber)).IncludeAllDerived();

            CreateMap<ContractNotice, ContractNoticeListDto>()
                .Ignore(x => x.CnTos).IncludeAllDerived()
                .ForMember(dest => dest.RequestByName, opt => opt.MapFrom(src => src.RequestBy == null ? "" : src.RequestBy.FirstName + " " + src.RequestBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.RequestOnBehalfName, opt => opt.MapFrom(src => src.RequestOnBehalf == null ? "" : src.RequestOnBehalf.FirstName + " " + src.RequestOnBehalf.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.NumberOfResponses, opt => opt.MapFrom(src => src.CnResponses.Count())).IncludeAllDerived()
                .ForMember(dest => dest.NumberOfActionedResponses, opt => opt.MapFrom(src => src.CnResponses.Count(x => x.DateActioned != null))).IncludeAllDerived();
            CreateMap<ContractNotice, CnNotificationTemplateDto>()
                .Ignore(x => x.CnTos).IncludeAllDerived()
                .ForMember(dest => dest.RequestByName, opt => opt.MapFrom(src => src.RequestBy == null ? "" : src.RequestBy.FirstName + " " + src.RequestBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.RequestOnBehalfName, opt => opt.MapFrom(src => src.RequestOnBehalf == null ? "" : src.RequestOnBehalf.FirstName + " " + src.RequestOnBehalf.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.NumberOfResponses, opt => opt.MapFrom(src => src.CnResponses.Count())).IncludeAllDerived()
                .ForMember(dest => dest.NumberOfActionedResponses, opt => opt.MapFrom(src => src.CnResponses.Count(x => x.DateActioned != null))).IncludeAllDerived();
            CreateMap<ContractNotice, ContractNoticeListReportDto>();
            CreateMap<ContractNotice, ContractNoticeReportDto>();
            CreateMap<ContractNotice, ContractNotice_noBodyDto>();
            CreateMap<ContractNotice, ContractNoticeDto>();
            CreateMap<ContractNoticeTemplate, ContractNoticeTemplateListDto>();
            CreateMap<ContractNoticeTemplate, ContractNoticeTemplateDto>();
            CreateMap<ContractNotice, ContractNoticeRenderTemplateDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Description ?? "")).IncludeAllDerived()
                .ForMember(dest => dest.ProjectNumber, opt => opt.MapFrom(src => src.Project.ContractNumber ?? "")).IncludeAllDerived()
                ;
            CreateMap<CnTo, CnToDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.NoticeTo == null ? "" : src.NoticeTo.FirstName + " " + src.NoticeTo.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.EffectiveEmailAddress, opt => opt.MapFrom(src => src.NoticeTo == null ? src.NoticeEmail : src.NoticeTo.Email)).IncludeAllDerived();
            CreateMap<CnApproval, CnApprovalDto>()
                .ForMember(dest => dest.ConRef, opt => opt.MapFrom(src => src.ContractNotice.ConRef)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalSubjectHtml, opt => opt.MapFrom(src => src.Approval.SubjectHtml)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.Approval == null ? null : src.Approval.ApprovalNo)).IncludeAllDerived();
            CreateMap<CnControlledDoc, CnControlledDocDto>()
                .ForMember(dest => dest.CnNumber, opt => opt.MapFrom(src => src.ContractNotice.ConRef))
                .ForMember(dest => dest.CnSubjectHtml, opt => opt.MapFrom(src => src.ContractNotice.ConSubjectHtml))
                .ForMember(dest => dest.DocumentNo, opt => opt.MapFrom(src => src.CpDocument.DocumentNo))
                .ForMember(dest => dest.DocumentDesc, opt => opt.MapFrom(src => src.CpDocument.Description));
            CreateMap<CnEmail, CnEmailDto>()
                .ForMember(dest => dest.ConRef, opt => opt.MapFrom(src => src.ContractNotice.ConRef)).IncludeAllDerived()
                .ForMember(dest => dest.EmailDate, opt => opt.MapFrom(src => src.EmailLog.DateEmailed)).IncludeAllDerived()
                .ForMember(dest => dest.EmailSubject, opt => opt.MapFrom(src => src.EmailLog.Subject)).IncludeAllDerived()
                .ForMember(dest => dest.EmailLogNo, opt => opt.MapFrom(src => src.EmailLog.EmailLogNo)).IncludeAllDerived();
            CreateMap<CnItp, CnItpDto>()
                .ForMember(dest => dest.ConRef, opt => opt.MapFrom(src => src.ContractNotice.ConRef))
                .ForMember(dest => dest.ItpDocNumber, opt => opt.MapFrom(src => src.Itp.ItpDocnumber)).IncludeAllDerived()
                .ForMember(dest => dest.ItpName, opt => opt.MapFrom(src => src.Itp.Description)).IncludeAllDerived();
            CreateMap<CnInstruction, CnInstructionDto>()
                .ForMember(dest => dest.ConRef, opt => opt.MapFrom(src => src.ContractNotice.ConRef))
                .ForMember(dest => dest.InstructionNo, opt => opt.MapFrom(src => src.Instruction.InstructionNo)).IncludeAllDerived()
                .ForMember(dest => dest.InstructionDesc, opt => opt.MapFrom(src => src.Instruction.DescriptionHtml)).IncludeAllDerived();
            CreateMap<CnIncident, CnIncidentDto>()
                .ForMember(dest => dest.ConRef, opt => opt.MapFrom(src => src.ContractNotice.ConRef))
                .ForMember(dest => dest.IncidentNo, opt => opt.MapFrom(src => src.Incident.IncidentNo)).IncludeAllDerived()
                .ForMember(dest => dest.IncidentDesc, opt => opt.MapFrom(src => src.Incident.DescriptionHtml)).IncludeAllDerived();
            CreateMap<CnLot, CnLotDto>()
                .ForMember(dest => dest.ConRef, opt => opt.MapFrom(src => src.ContractNotice.ConRef))
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber))
                .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description));
            CreateMap<CnNotice, CnNoticeDto>()
                .ForMember(dest => dest.ConRef1, opt => opt.MapFrom(src => src.ContractNotice_CnId1.ConRef)).IncludeAllDerived()
                .ForMember(dest => dest.ConSubject1, opt => opt.MapFrom(src => src.ContractNotice_CnId1.SubjectHtmlTemp)).IncludeAllDerived()
                .ForMember(dest => dest.ConRef2, opt => opt.MapFrom(src => src.ContractNotice_CnId2.ConRef)).IncludeAllDerived()
                .ForMember(dest => dest.ConSubject2, opt => opt.MapFrom(src => src.ContractNotice_CnId2.SubjectHtmlTemp)).IncludeAllDerived();
            CreateMap<CnPhoto, CnPhotoDto>()
                .ForMember(dest => dest.CnNumber, opt => opt.MapFrom(src => src.ContractNotice.ConRef))
                .ForMember(dest => dest.CnSubjectHtml, opt => opt.MapFrom(src => src.ContractNotice.ConSubjectHtml))
                .ForMember(dest => dest.PhotoDescription, opt => opt.MapFrom(src => src.Photo.Description))
                .ForMember(dest => dest.PhotoNo, opt => opt.MapFrom(src => src.Photo.PhotoNo));
            CreateMap<CnVariation, CnVariationDto>()
                .ForMember(dest => dest.ConRef, opt => opt.MapFrom(src => src.ContractNotice.ConRef))
                .ForMember(dest => dest.VariationNo, opt => opt.MapFrom(src => src.Variation.VariationNo))
                .ForMember(dest => dest.VariationDesc, opt => opt.MapFrom(src => src.Variation.Description));
            CreateMap<CnResponse, CnResponseListDto>()
                .ForMember(dest => dest.ResponseByName, opt => opt.MapFrom(src => src.ResponseBy == null ? "" : src.ResponseBy.FirstName + " " + src.ResponseBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ContractNoticeReference, opt => opt.MapFrom(src => src.ContractNotice.ConRef)).IncludeAllDerived()
                .ForMember(dest => dest.ContractNoticeSubjectHtml, opt => opt.MapFrom(src => src.ContractNotice.ConSubjectHtml)).IncludeAllDerived();
            CreateMap<CnResponse, CnResponseDto>()
                .ForMember(dest => dest.ActionRequiredByName, opt => opt.MapFrom(src => src.ActionRequiredBy == null ? "" : src.ActionRequiredBy.FirstName + " " + src.ActionRequiredBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ActionCompletedByName, opt => opt.MapFrom(src => src.ActionCompletedBy == null ? "" : src.ActionCompletedBy.FirstName + " " + src.ActionCompletedBy.LastName)).IncludeAllDerived()
;
            CreateMap<CnResponse, CnResponseTemplateDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ContractNotice.Project.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ProjectNumber, opt => opt.MapFrom(src => src.ContractNotice.Project.ContractNumber)).IncludeAllDerived();
            CreateMap<CpDocument, CpDocumentDto>();
            CreateMap<CpDocument, CpDocumentTemplateDto>()
                .ForMember(dest => dest.LastRevDate, opt => opt.MapFrom(src => src.Revisions.OrderByDescending(x => x.RevisionDate).Select(x => x.RevisionDate).FirstOrDefault())).IncludeAllDerived()
                .ForMember(dest => dest.LastRevRef, opt => opt.MapFrom(src => src.Revisions.OrderByDescending(x => x.RevisionDate).Select(x => x.RevRef).FirstOrDefault())).IncludeAllDerived();
            if (!IsApi) CreateMap<ControlLine, ControlLineDto>();
            CreateMap<ControlLinePoint, ControlLinePointDto>();
            CreateMap<CostCode, CostCodeDto>();
            CreateMap<CustomRegister, CustomRegisterLookupDto>();
            int RegisterTypeId = -1;
            if (!IsApi) CreateMap<CustomRegister, CustomRegisterDto>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.CustomRegisterActivations.Any(x => x.ActivatedRegisterId == RegisterTypeId &&
                    (x.IsActive ?? false)))).IncludeAllDerived()
                .ForMember(dest => dest.IsRequired, opt => opt.MapFrom(src => src.CustomRegisterActivations.Any(x => x.ActivatedRegisterId == RegisterTypeId &&
                    (x.IsRequired ?? false)))).IncludeAllDerived()
                .ForMember(dest => dest.IsReported, opt => opt.MapFrom(src => src.CustomRegisterActivations.Any(x => x.ActivatedRegisterId == RegisterTypeId &&
                    (x.IsReported ?? false)))).IncludeAllDerived();
            CreateMap<CustomRegister, CustomRegisterExportDto>();
            CreateMap<CustomRegisterItem, CustomRegisterItemDto>();
            CreateMap<CustomRegisterValue, CustomRegisterValueDto>()
                .ForMember(dest => dest.CrItemText, opt => opt.MapFrom(src => src.CustomRegisterItem == null ? "" : src.CustomRegisterItem.CustomRegisterValue)).IncludeAllDerived()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.CustomRegister == null ? null : src.CustomRegister.OrderId)).IncludeAllDerived()
                .ForMember(dest => dest.ValueTypeId, opt => opt.MapFrom(src => src.CustomRegister == null ? null : src.CustomRegister.ValueTypeId)).IncludeAllDerived();
            CreateMap<CustomRegisterValue, CustomRegisterValueReportDto>()
                .ForMember(dest => dest.CustomRegisterText, opt => opt.MapFrom(src => src.CustomRegister == null ? "" : src.CustomRegister.CustomRegisterName)).IncludeAllDerived();
            CreateMap<CustomRegisterItem, CustomRegisterItemLookupDto>();
            CreateMap<CustomRegisterItem, CustomRegisterItemExportDto>();

            CreateMap<DayCost, DayCostListDto>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.SupplierObj.SupplierName)).IncludeAllDerived()
                .ForMember(dest => dest.ResourceName, opt => opt.MapFrom(src => src.ResourceObj.ResourceName)).IncludeAllDerived();
            CreateMap<Distribution, DistributionDto>()
                .ForMember(dest => dest.DocumentDesc, opt => opt.MapFrom(src => src.CpDocument.Description)).IncludeAllDerived()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User == null ? "" : src.User.FirstName + " " + src.User.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.DocumentNo, opt => opt.MapFrom(src => src.CpDocument.DocumentNo)).IncludeAllDerived();

            CreateMap<EmailLog, EmailLogDto>();
            CreateMap<EmailLog, EmailLogListDto>();

            CreateMap<FileStoreDoc, FileStoreDocDto>();
            CreateMap<FileStoreDoc, FileStoreDocTemplateDto>();
            CreateMap<ForecastWlDistro, ForecastWLDistroDto>()
                .ForMember(dest => dest.CostCodeName, opt => opt.MapFrom(src => src.CostCode.CostCodeName)).IncludeAllDerived()
                .ForMember(dest => dest.CostCodeDescription, opt => opt.MapFrom(src => src.CostCode.Description)).IncludeAllDerived();
            CreateMap<FsTestReq, FsTestReqTemplateDto>()
                .ForMember(dest => dest.TestReqNo, opt => opt.MapFrom(src => src.TestRequest.TestRequestNo)).IncludeAllDerived()
                .ForMember(dest => dest.TestReqDesc, opt => opt.MapFrom(src => src.TestRequest.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FileDate, opt => opt.MapFrom(src => src.FileStoreDoc.FileDate)).IncludeAllDerived()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived();
            CreateMap<FsApproval, FsApprovalDto>()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalSubjectHtml, opt => opt.MapFrom(src => src.Approval.SubjectHtml)).IncludeAllDerived()
                .ForMember(dest => dest.FilestoreDocNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.Approval == null ? null : src.Approval.ApprovalNo)).IncludeAllDerived();
            CreateMap<FsAtp, FsAtpDto>()
                .ForMember(dest => dest.AtpNo, opt => opt.MapFrom(src => src.Atp.AtpNo)).IncludeAllDerived()
                .ForMember(dest => dest.AtpDesc, opt => opt.MapFrom(src => src.Atp.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived();
            CreateMap<FsEmail, FsEmailDto>()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.EmailSubject, opt => opt.MapFrom(src => src.EmailLog == null ? "" : src.EmailLog.Subject)).IncludeAllDerived()
                .ForMember(dest => dest.EmailLogNo, opt => opt.MapFrom(src => src.EmailLog == null ? 0 : src.EmailLog.EmailLogNo)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived();
            CreateMap<FsNotice, FsNoticeDto>()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived()
                .ForMember(dest => dest.CnSubjectHtml, opt => opt.MapFrom(src => src.ContractNotice.ConSubjectHtml)).IncludeAllDerived()
                .ForMember(dest => dest.CnRef, opt => opt.MapFrom(src => src.ContractNotice == null ? null : src.ContractNotice.ConRef)).IncludeAllDerived();
            CreateMap<FsDoc, FsDocDto>()
                .ForMember(dest => dest.DocumentNo, opt => opt.MapFrom(src => src.CpDocument.DocumentNo)).IncludeAllDerived()
                .ForMember(dest => dest.DocumentDesc, opt => opt.MapFrom(src => src.CpDocument.Description)).IncludeAllDerived()
                .ForMember(dest => dest.Revision, opt => opt.MapFrom(src => src.Revision.RevRef)).IncludeAllDerived()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived();
            CreateMap<FsIncident, FsIncidentDto>()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.IncidentNo, opt => opt.MapFrom(src => src.Incident.IncidentNo)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived()
                .ForMember(dest => dest.IncidentDesc, opt => opt.MapFrom(src => src.Incident.DescriptionHtml)).IncludeAllDerived();
            CreateMap<FsInstruction, FsInstructionDto>()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.InstructionNo, opt => opt.MapFrom(src => src.Instruction.InstructionNo)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived()
                .ForMember(dest => dest.InstructionDescription, opt => opt.MapFrom(src => src.Instruction.DescriptionHtml)).IncludeAllDerived();
            CreateMap<FsLot, FsLotDto>()
                .ForMember(dest => dest.FullLotDesc, opt => opt.MapFrom(src => src.Lot == null ? "" : src.Lot.LotNumber + ": " + src.Lot.Description)).IncludeAllDerived()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived();
            CreateMap<FsNotification, FsNotificationDto>()
                .ForMember(dest => dest.FullNotificationDesc, opt => opt.MapFrom(src => src.Notification == null ? "" : src.Notification.NotificationNo + ": " + src.Notification.SubjectText)).IncludeAllDerived()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived();
            CreateMap<FsNcr, FsNcrDto>()
                .ForMember(dest => dest.NcrNo, opt => opt.MapFrom(src => src.Ncr.NcrNo)).IncludeAllDerived()
                .ForMember(dest => dest.NcrDesc, opt => opt.MapFrom(src => src.Ncr.Description)).IncludeAllDerived()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived();
            CreateMap<FsSurvey, FsSurveyDto>()
                .ForMember(dest => dest.SrNumber, opt => opt.MapFrom(src => src.SurveyRequest.SrNumber)).IncludeAllDerived()
                .ForMember(dest => dest.SurveyDesc, opt => opt.MapFrom(src => src.SurveyRequest.Description)).IncludeAllDerived()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDate, opt => opt.MapFrom(src => src.FileStoreDoc.FileDate)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived();
            CreateMap<FsPunchlistItem, FsPunchlistItemDto>()
                .ForMember(dest => dest.PunchlistNo, opt => opt.MapFrom(src => src.PunchlistItem.Punchlist.PunchlistNo)).IncludeAllDerived()
                .ForMember(dest => dest.PunchlistName, opt => opt.MapFrom(src => src.PunchlistItem.Punchlist.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PunchlistItemNo, opt => opt.MapFrom(src => src.PunchlistItem.ItemNo)).IncludeAllDerived()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived();
            CreateMap<FsPurchaseOrder, FsPurchaseOrderDto>()
                .ForMember(dest => dest.FullPoDesc, opt => opt.MapFrom(src => src.PurchaseOrder == null ? "" : src.PurchaseOrder.PoNumber + ": " + src.PurchaseOrder.Supplier.SupplierName)).IncludeAllDerived()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived();
            CreateMap<FsSupplier, FsSupplierDto>()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.SupplierName)).IncludeAllDerived();
            CreateMap<FsTestReq, FsTestReqDto>()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDate, opt => opt.MapFrom(src => src.FileStoreDoc.FileDate)).IncludeAllDerived()
                .ForMember(dest => dest.TestReqNo, opt => opt.MapFrom(src => src.TestRequest.TestRequestNo)).IncludeAllDerived()
                .ForMember(dest => dest.TestReqDesc, opt => opt.MapFrom(src => src.TestRequest.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived();
            CreateMap<FsVariation, FsVariationDto>()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived()
                .ForMember(dest => dest.VariationNo, opt => opt.MapFrom(src => src.Variation == null ? "" : src.Variation.VariationNo)).IncludeAllDerived()
                .ForMember(dest => dest.VariationDesc, opt => opt.MapFrom(src => src.Variation == null ? null : src.Variation.Description)).IncludeAllDerived();
            CreateMap<FsWorkflowLog, FsWorkflowLogDto>()
                .ForMember(dest => dest.FirstLast, opt => opt.MapFrom(src => src.WorkflowLog.User == null ? "" : src.WorkflowLog.User.FirstName + " " + src.WorkflowLog.User.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived()
                .ForMember(dest => dest.LogDate, opt => opt.MapFrom(src => src.WorkflowLog.LogDate)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalId, opt => opt.MapFrom(src => src.WorkflowLog.Workflow.Approvals.FirstOrDefault().ApprovalId)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.WorkflowLog.Workflow.Approvals.FirstOrDefault().ApprovalNo)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived();
            CreateMap<SurveyRequest, SurveyRequestTemplateDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ProjectNumber, opt => opt.MapFrom(src => src.Project.ContractNumber)).IncludeAllDerived()
                .ForMember(dest => dest.FilestoreDocsOrdered, opt => opt.MapFrom(src => src.FsSurveys.Select(x => x.FileStoreDoc).OrderByDescending(x => x.FileDate))).IncludeAllDerived()
                .ForMember(dest => dest.LotsOrdered, opt => opt.MapFrom(src => src.LotSurveys.OrderBy(x => x.LotId))).IncludeAllDerived()
                .ForMember(dest => dest.Approvals, opt => opt.MapFrom(src => src.ApprovalSurveys.OrderBy(x => x.ApprovalId))).IncludeAllDerived();
            CreateMap<FsSurvey, FsSurveyRequestTemplateDto>()
                .ForMember(dest => dest.SurveyRequestNo, opt => opt.MapFrom(src => src.SurveyRequest.SrNumber)).IncludeAllDerived()
                .ForMember(dest => dest.SurveyRequestDesc, opt => opt.MapFrom(src => src.SurveyRequest.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FsNo, opt => opt.MapFrom(src => src.FileStoreDoc.FilestoreDocNo)).IncludeAllDerived()
                .ForMember(dest => dest.FileDesc, opt => opt.MapFrom(src => src.FileStoreDoc.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FileDate, opt => opt.MapFrom(src => src.FileStoreDoc.FileDate)).IncludeAllDerived()
                .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileStoreDoc.Filename)).IncludeAllDerived();

            CreateMap<ImageLayer, ImageLayerDto>();
            CreateMap<ImageLayerPoint, ImageLayerPointDto>();
            CreateMap<Incident, IncidentTemplateDto>()
                .ForMember(dest => dest.IncidentTypeName, opt => opt.MapFrom(src => src.IncidentType.IncidentTypeName)).IncludeAllDerived();
            CreateMap<Incident, IncidentListDto>()
                .ForMember(dest => dest.RaisedByName, opt => opt.MapFrom(src => src.RaisedBy == null ? "" : src.RaisedBy.FirstName + " " + src.RaisedBy.LastName)).IncludeAllDerived();
            CreateMap<Incident, IncidentReportDto>()
                .ForMember(dest => dest.IncidentTypeName, opt => opt.MapFrom(src => src.IncidentType == null ? "" : src.IncidentType.IncidentTypeName)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovedByName, opt => opt.MapFrom(src => src.ApprovedBy == null ? "" : src.ApprovedBy.FirstName + " " + src.ApprovedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ClosedOutName, opt => opt.MapFrom(src => src.CloseoutBy == null ? "" : src.CloseoutBy.FirstName + " " + src.CloseoutBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ReportedByName, opt => opt.MapFrom(src => src.ReportedBy == null ? "" : src.ReportedBy.FirstName + " " + src.ReportedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ReportedToName, opt => opt.MapFrom(src => src.ReportedTo == null ? "" : src.ReportedTo.FirstName + " " + src.ReportedTo.LastName)).IncludeAllDerived();

            CreateMap<Incident, IncidentDto>()
                .ForMember(dest => dest.ReportedToName, opt => opt.MapFrom(src => src.ReportedTo == null ? "" : src.ReportedTo.FirstName + " " + src.ReportedTo.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ReportedByName, opt => opt.MapFrom(src => src.ReportedBy == null ? "" : src.ReportedBy.FirstName + " " + src.ReportedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.IncidentTypeName, opt => opt.MapFrom(src => src.IncidentType == null ? "" : src.IncidentType.IncidentTypeName)).IncludeAllDerived()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.CloseOutDate != null? "closed out" :
                src.ApprovedDate != null ? "approved" : "open"));
            CreateMap<Instruction, InstructionListDto>()
                .ForMember(dest => dest.InstructionByName, opt => opt.MapFrom(src => src.InstructionBy == null ? "" : src.InstructionBy.FirstName + " " + src.InstructionBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.InstructionToName, opt => opt.MapFrom(src => src.InstructionTo == null ? "" : src.InstructionTo.FirstName + " " + src.InstructionTo.LastName)).IncludeAllDerived();
            CreateMap<Instruction, InstructionDto>();
            CreateMap<Instruction, InstructionTemplateDto>();
            CreateMap<Invoice, InvoiceListDto>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.SupplierName)).IncludeAllDerived();
            CreateMap<Itp, ItpListDto>()
                .ForMember(dest => dest.HasScheduleLink, opt => opt.MapFrom(src => src.ItpScheduleItems.Count > 0)).IncludeAllDerived();
            CreateMap<Itp, ItpDto>();
            CreateMap<ItpDetail, ItpDetailDto>()
                .ForMember(dest => dest.TestCount, opt => opt.MapFrom(src => src.ItpTestings.Count)).IncludeAllDerived();
            CreateMap<ItpTesting, ItpTestingDto>()
                 .ForMember(dest => dest.TestMethodName, opt => opt.MapFrom(src => src.TestMethod == null ? "" : src.TestMethod.TestNum + ": " + src.TestMethod.TestDescription)).IncludeAllDerived();
            CreateMap<Itp, ItpTemplateDto>();
            CreateMap<ItpDetailWorkflow, ItpDetailWorkflowDto>()
                .ForMember(dest => dest.WorkflowName, opt => opt.MapFrom(src => src.ApprovalWorkflow.Description)).IncludeAllDerived();
            CreateMap<IncidentType, IncidentTypeDto>();
            CreateMap<IncidentPerson, IncidentPersonDto>()
                .ForMember(dest => dest.ContactCompany, opt => opt.MapFrom(src => src.Contact == null ? "" : src.Contact.Company))
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Contact == null ? "" : src.Contact.FirstName + " " + src.Contact.LastName))
                .ForMember(dest => dest.IncidentNo, opt => opt.MapFrom(src => src.Incident.IncidentNo));
            CreateMap<ItpScheduleItem, ItpScheduleDto>()
                .ForMember(dest => dest.ItpDocNo, opt => opt.MapFrom(src => src.Itp.ItpDocnumber)).IncludeAllDerived()
                .ForMember(dest => dest.ItpDescription, opt => opt.MapFrom(src => src.Itp.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleNo, opt => opt.MapFrom(src => src.ScheduleItem.ScheduleNumber)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleDesc, opt => opt.MapFrom(src => src.ScheduleItem.Description)).IncludeAllDerived();

            CreateMap<Lot, LotShortListDto>();
            CreateMap<Lot, LotListForMapShortDto>();
            CreateMap<Lot, LotListForMapDto>();

            bool IsSupportPreopen = false;
            if (!IsCe) CreateMap<Lot, LotListDto>()
                .ForMember(dest => dest.PrimaryTag, opt => opt.MapFrom(src => src.TagCode.TagName)).IncludeAllDerived()
                .ForMember(dest => dest.LotStatus, opt => opt.MapFrom(src =>
                        src.DateRejected != null ? Models.Lot.RejectedString :
                        src.DateConf != null ? "conformed" :
                        src.DateGuar != null ? "guaranteed" :
                        IsSupportPreopen && (src.DateWorkSt == null) ? "pre-open" : "open")).IncludeAllDerived()
                .ForMember(dest => dest.EffPercentComplete, opt => opt.MapFrom(src => src.DateConf != null || src.DateGuar != null ? 1 : src.PercentComplete)).IncludeAllDerived();

            CreateMap<Lot, LotDto>()
                .ForMember(dest => dest.RaisedByName, opt => opt.MapFrom(src => src.RaisedBy == null ? "" : src.RaisedBy.FirstName + " " + src.RaisedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ControlLineName, opt => opt.MapFrom(src => src.ControlLine.ControlLineName)).IncludeAllDerived();

            CreateMap<Lot, LotBasicTemplateDto>();
            CreateMap<Lot, LotTemplateDto>()
                .ForMember(dest => dest.LotStatus, opt => opt.MapFrom(src =>
                        src.DateRejected != null ? Models.Lot.RejectedString :
                        src.DateConf != null ? "conformed" :
                        src.DateGuar != null ? "guaranteed" :
                        IsSupportPreopen && (src.DateWorkSt == null) ? "pre-open" : "open")).IncludeAllDerived()
                .ForMember(dest => dest.RaisedByName, opt => opt.MapFrom(src => src.RaisedBy == null ? "" : src.RaisedBy.FirstName + " " + src.RaisedBy.LastName)).IncludeAllDerived();

            CreateMap<Lot, LotWithCalcPropsDto>()
                .ForMember(dest => dest.LotStatus, opt => opt.MapFrom(src =>
                        src.DateRejected != null ? "rejected" :
                        src.DateConf != null ? "conformed" :
                        src.DateGuar != null ? "guaranteed" :
                        ((src.Project.SystemProjectControls.FirstOrDefault(x => x.Key.ToLower() == "supportpreopen").Value ?? "false").ToLower() == "true") && (src.DateWorkSt == null) ? "pre-open" : "open")).IncludeAllDerived()
                .ForMember(dest => dest.EffPercentComplete, opt => opt.MapFrom(src => src.DateConf != null || src.DateGuar != null ? 1 : src.PercentComplete)).IncludeAllDerived()
                .ForMember(dest => dest.ControlLineString, opt => opt.MapFrom(src => src.ControlLine.ControlLineName))
                .ForMember(dest => dest.NCRCount, opt => opt.MapFrom(src => src.NcrLots.Count))
                .ForMember(dest => dest.ATPCount, opt => opt.MapFrom(src => src.AtpLots.Count))
                .ForMember(dest => dest.TRCount, opt => opt.MapFrom(src => src.TestRequests.Count))
                .ForMember(dest => dest.FsDocCount, opt => opt.MapFrom(src => src.FsLots.Count))
                .ForMember(dest => dest.NCRCountUnapp, opt => opt.MapFrom(src => src.NcrLots.Count == 0 ? 0 : src.NcrLots.Where(x => x.Ncr.ApprovalDate == null && x.Ncr.CloseOutDate == null).Count()))
                .ForMember(dest => dest.ATPCountUnapp, opt => opt.MapFrom(src => src.AtpLots.Count == 0 ? 0 : src.AtpLots.Where(x => x.DateApproved == null).Count()))
                .ForMember(dest => dest.TRCountIncomp, opt => opt.MapFrom(src => src.TestRequests.Count == 0 ? 0 : src.TestRequests.Where(x => x.DateTestCompleted == null).Count()))
                .ForMember(dest => dest.LotValue, opt => opt.MapFrom(src => src.LotQuantities.Sum(x => x.Qty * (x.ScheduleItem.SellRate ?? 0)))).IncludeAllDerived()
                .ForMember(dest => dest.EffValue, opt => opt.MapFrom(src => (src.DateConf != null || src.DateGuar != null ? 1 : src.PercentComplete)
                    * src.LotQuantities.Sum(x => x.Qty * (x.ScheduleItem.SellRate ?? 0) * x.ReducedPayment * ((x.NonClaimable ?? false) ? 0 : 1))))
                .ForMember(dest => dest.RPValue, opt => opt.MapFrom(src => src.LotQuantities.Sum(x => (x.NonClaimable ?? false) ? 0 : x.Qty * (x.ScheduleItem.SellRate ?? 0) * (1 - x.ReducedPayment))));

            CreateMap<LotCoordinate, LotCoordinateDto>();
            CreateMap<LotInstruction, LotInstructionDto>()
                .ForMember(dest => dest.InstructionDescriptionHtml, opt => opt.MapFrom(src => src.Instruction.DescriptionHtml)).IncludeAllDerived()
                .ForMember(dest => dest.InstructionDate, opt => opt.MapFrom(src => src.Instruction.InstructionDate))
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber))
                .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description))
                .ForMember(dest => dest.InstructionNo, opt => opt.MapFrom(src => src.Instruction.InstructionNo));

            CreateMap<LotRelation, LotRelationDto>()
                .ForMember(dest => dest.Lot1Number, opt => opt.MapFrom(src => src.Lot1.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.Lot2Number, opt => opt.MapFrom(src => src.Lot2.LotNumber)).IncludeAllDerived();
            CreateMap<LotRelation, LotRelationFullDto>()
                .ForMember(dest => dest.Lot1Description, opt => opt.MapFrom(src => src.Lot1.Description)).IncludeAllDerived()
                .ForMember(dest => dest.Lot2Description, opt => opt.MapFrom(src => src.Lot2.Description)).IncludeAllDerived();
            CreateMap<LotTag, LotTagDto>()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description)).IncludeAllDerived()
                .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.TagCode.TagName)).IncludeAllDerived()
                .ForMember(dest => dest.TagDescription, opt => opt.MapFrom(src => src.TagCode.Description)).IncludeAllDerived();
            CreateMap<LotItp, LotItpLookupDto>()
                .ForMember(dest => dest.ItpName, opt => opt.MapFrom(src => src.Itp.Description)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived();
            if (!IsCe) CreateMap<LotItp, LotItpDto>()
                .ForMember(dest => dest.ItpName, opt => opt.MapFrom(src => src.Itp.Description)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.AllChecked, opt => opt.MapFrom(src => !src.LotItpDetails.Any(x => (x.CheckReqd ?? false)
                    && x.CheckDate == null && x.NotApplicableDate == null && x.NcrId == null))).IncludeAllDerived()
                .ForMember(dest => dest.AllVerified, opt => opt.MapFrom(src => !src.LotItpDetails.Any(x => (x.VerifyReqd ?? false)
                    && x.VerifyDate == null && x.NotApplicableDate == null && x.NcrId == null))).IncludeAllDerived()
                .ForMember(dest => dest.AllApproved, opt => opt.MapFrom(src => !src.LotItpDetails.Any(x => (x.ApprovalReqd ?? false)
                    && x.NotApplicableDate == null && x.NcrId == null && x.ApproveDate == null
                    && !(x.Approval.IsCompleted ?? false) && x.Approval.DateDirectlyApproved == null
                    && x.Approval.CloseOutDate == null))).IncludeAllDerived()
                .ForMember(dest => dest.RaisedByName, opt => opt.MapFrom(src => src.RaisedBy == null ? "" : src.RaisedBy.FirstName + " " + src.RaisedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovedByName, opt => opt.MapFrom(src => src.ApprovedBy == null ? "" : src.ApprovedBy.FirstName + " " + src.ApprovedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.DateRejected, opt => opt.MapFrom(src => src.Lot.DateRejected)).IncludeAllDerived()
                .ForMember(dest => dest.WorkTypeName, opt => opt.MapFrom(src => src.Lot.WorkType.WorkTypeName)).IncludeAllDerived()
                .ForMember(dest => dest.AreaCodeName, opt => opt.MapFrom(src => src.Lot.AreaCode.AreaCodeName)).IncludeAllDerived()
                .ForMember(dest => dest.DateConformed, opt => opt.MapFrom(src => src.Lot.DateConf)).IncludeAllDerived()
                .ForMember(dest => dest.DateGuaranteed, opt => opt.MapFrom(src => src.Lot.DateGuar)).IncludeAllDerived()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Lot == null ? "No Lot Ref" :
                    src.Lot.DateRejected != null ? Models.Lot.RejectedString :
                    src.Lot.DateConf != null ? "Conformed" :
                    src.Lot.DateGuar != null ? "Guaranteed" :
                    src.Lot.DateClosed != null ? "Closed" : "Open")).IncludeAllDerived();
            if (!IsCe) CreateMap<LotItp, LotItpTemplateDto>()
                .ForMember(dest => dest.ItpName, opt => opt.MapFrom(src => src.Itp.Description)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.RaisedByName, opt => opt.MapFrom(src => src.RaisedBy == null ? "" : src.RaisedBy.FirstName + " " + src.RaisedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovedByName, opt => opt.MapFrom(src => src.ApprovedBy == null ? "" : src.ApprovedBy.FirstName + " " + src.ApprovedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.DateRejected, opt => opt.MapFrom(src => src.Lot.DateRejected)).IncludeAllDerived()
                .ForMember(dest => dest.DateConformed, opt => opt.MapFrom(src => src.Lot.DateConf)).IncludeAllDerived()
                .ForMember(dest => dest.DateGuaranteed, opt => opt.MapFrom(src => src.Lot.DateGuar)).IncludeAllDerived()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Lot == null ? "No Lot Ref" :
                    src.Lot.DateRejected != null ? Models.Lot.RejectedString :
                    src.Lot.DateConf != null ? "Conformed" :
                    src.Lot.DateGuar != null ? "Guaranteed" :
                    src.Lot.DateClosed != null ? "Closed" : "Open")).IncludeAllDerived();
            CreateMap<LotItpDetail, LotItpDetailForTreeDto>()
                .ForMember(dest => dest.ItpName, opt => opt.MapFrom(src => src.LotItp.Itp.Description)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.LotItp.Lot.LotNumber)).IncludeAllDerived();
            CreateMap<LotItpDetail, LotItpDetailDto>()
                .ForMember(dest => dest.NcrNo, opt => opt.MapFrom(src => src.Ncr.NcrNo)).IncludeAllDerived()
                .ForMember(dest => dest.HasTests, opt => opt.MapFrom(src => !(src.LotItpTests.Count == 0))).IncludeAllDerived()
                .ForMember(dest => dest.IsLatestStepAlert, opt => opt.MapFrom(src => src.Approval.IsLatestStepAlert ?? false)).IncludeAllDerived()
                .ForMember(dest => dest.HasStandingApproval, opt => opt.MapFrom(src => src.ApprovalLotItpDetails.Count > 0)).IncludeAllDerived()
                .ForMember(dest => dest.LatestApprovalStatus, opt => opt.MapFrom(src =>
                    src.Approval == null ? (src.ApproveDate != null ? "Directly Approved" : "Open") :
                    src.Approval.DateDirectlyApproved != null ? "Manually Approved" :
                    (src.Approval.IsCompleted ?? false) ? src.Approval.StatusLastStep :
                    src.Approval.CloseOutDate != null ? "Closed Out (Approval)" :
                    src.Approval.StatusLastStep ?? "Not started"
                    )).IncludeAllDerived()
                .ForMember(dest => dest.IsApprovedToProceed, opt => opt.MapFrom(src =>
                    src.ApproveDate != null ||
                    (src.Approval.IsApprovedToProceed ?? false) ||
                    src.Approval.DateDirectlyApproved != null ||
                    (src.Approval.IsCompleted ?? false))).IncludeAllDerived()
                .ForMember(dest => dest.IsApprovalCompleted, opt => opt.MapFrom(src =>
                    src.ApproveDate != null ||
                    src.Approval.CloseOutDate != null ||
                    src.Approval.DateDirectlyApproved != null ||
                    (src.Approval.IsCompleted ?? false))).IncludeAllDerived();
            CreateMap<LotItpDetail, LotItpDetailTemplateDto>()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.LotItp.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.LotItp.Lot.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ItpDocNo, opt => opt.MapFrom(src => src.LotItp.SourceItpNo)).IncludeAllDerived()
                .ForMember(dest => dest.ItpName, opt => opt.MapFrom(src => src.LotItp.Itp.Description)).IncludeAllDerived();
            CreateMap<LotItpTest, LotItpTestDto>()
                .ForMember(dest => dest.IsReducedLevelOfTesting, opt => opt.MapFrom(src => (src.LotItpDetail.LotItp.Lot.TestRed ?? false))).IncludeAllDerived()
                .ForMember(dest => dest.TestMethodName, opt => opt.MapFrom(src => src.TestMethod == null ? "" : src.TestMethod.TestNum + ": " + src.TestMethod.TestDescription)).IncludeAllDerived();
            CreateMap<LotMapSection, LotMapSectionEditDto>();
            CreateMap<LotMapSection, LotMapSectionDto>()
            .ForMember(dest => dest.ControlLineName, opt => opt.MapFrom(src => src.ControlLine.ControlLineName)).IncludeAllDerived()
            .ForMember(dest => dest.CustomRegisterName, opt => opt.MapFrom(src => src.CustomRegister.CustomRegisterName)).IncludeAllDerived();
            CreateMap<LotMapSection, LotMapSectionForLayoutDto>();
            CreateMap<LotMapSectionLot, LotMapSectionLotDto>()
            .ForMember(dest => dest.LayerOrderId, opt => opt.MapFrom(src => src.LotMapLayer.OrderId)).IncludeAllDerived()
            .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description)).IncludeAllDerived()
            .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived();
            CreateMap<LotMapLayer, LotMapLayerForLayoutDto>()
                .ForMember(dest => dest.CustomRegisterItemName, opt => opt.MapFrom(src => src.CustomRegisterItem.CustomRegister.CustomRegisterName)).IncludeAllDerived();
            CreateMap<LotMapLayer, LotMapLayerLookupDto>();
            CreateMap<LotMapLayer, LotMapLayerDto>()
                .ForMember(dest => dest.WorkTypeName, opt => opt.MapFrom(src => src.WorkType.WorkTypeName)).IncludeAllDerived()
                .ForMember(dest => dest.CustomRegisterItemName, opt => opt.MapFrom(src => src.CustomRegisterItem.CustomRegisterValue)).IncludeAllDerived();

            CreateMap<LotPunchlistItem, LotPunchlistItemDto>()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PunchlistNo, opt => opt.MapFrom(src => src.PunchlistItem.Punchlist.PunchlistNo)).IncludeAllDerived()
                .ForMember(dest => dest.PunchlistName, opt => opt.MapFrom(src => src.PunchlistItem.Punchlist.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PunchlistItemNo, opt => opt.MapFrom(src => src.PunchlistItem.ItemNo)).IncludeAllDerived();
            CreateMap<LotQuantity, LotQuantityListDto>()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.EffDescription, opt => opt.MapFrom(src => src.LotId == null ? src.Description : src.Lot.LotNumber + ": " + src.Lot.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleName, opt => opt.MapFrom(src => src.ScheduleItem == null ? "" : src.ScheduleItem.ScheduleNumber + ": " + src.ScheduleItem.Description)).IncludeAllDerived()
                .ForMember(dest => dest.EffectivePercComp, opt => opt.MapFrom(src => src.Lot == null ? src.PercComp :
                    (src.Lot.DateConf != null || src.Lot.DateGuar != null) ? 1 :
                    ((src.PercComp.HasValue && src.PercComp.Value < 1) ? src.PercComp ?? 0 : src.Lot.PercentComplete ?? 0))).IncludeAllDerived();
            CreateMap<LotQuantity, LotQuantityWithConfDto>()
                .ForMember(dest => dest.LotDateConf, opt => opt.MapFrom(src => src.Lot == null ? null : src.Lot.DateConf)).IncludeAllDerived()
                .ForMember(dest => dest.LotDateGuar, opt => opt.MapFrom(src => src.Lot == null ? null : src.Lot.DateGuar)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleNo, opt => opt.MapFrom(src => src.ScheduleItem.ScheduleNumber)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleDescription, opt => opt.MapFrom(src => src.ScheduleItem.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleSellRate, opt => opt.MapFrom(src => src.ScheduleItem.SellRate)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleUnit, opt => opt.MapFrom(src => src.ScheduleItem.Unit)).IncludeAllDerived();
            CreateMap<LotQuantity, LotQuantityDto>()
                .ForMember(dest => dest.ApprovedByName, opt => opt.MapFrom(src => src.ApprovedBy == null ? null : src.ApprovedBy.FirstName + " " + src.ApprovedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.SellRate, opt => opt.MapFrom(src => src.ScheduleItem.SellRate)).IncludeAllDerived()
                .ForMember(dest => dest.DjcRate, opt => opt.MapFrom(src => src.ScheduleItem.DjcRate)).IncludeAllDerived()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => (src.ScheduleItem.SellRate ?? 0) * (src.Qty ?? 0))).IncludeAllDerived()
                .ForMember(dest => dest.LotAdjDate, opt => opt.MapFrom(src => src.Lot == null ? src.ModifiedOn :
                    src.Lot.DateRejected != null ? src.Lot.DateRejected :
                    src.Lot.DateConf != null ? src.Lot.DateConf :
                    src.Lot.DateGuar != null ? src.Lot.DateGuar :
                    src.Lot.DateOpen)).IncludeAllDerived();
            CreateMap<LotUser, LotUserDto>()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User == null ? "" : src.User.FirstName + " " + src.User.LastName)).IncludeAllDerived();

            CreateMap<Ncr, NcrListDto>()
                .ForMember(dest => dest.RaisedByName, opt => opt.MapFrom(src => src.RaisedBy == null ? "" : src.RaisedBy.FirstName + " " + src.RaisedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.LqSell, opt => opt.MapFrom(src => src.LotQuantities.Sum(x => Math.Round(((x.NonClaimable ?? false) ? 0 : 1) * x.Qty ?? 0 * x.ScheduleItem.SellRate ?? 0, 2)))).IncludeAllDerived()
                .ForMember(dest => dest.LqRpVal, opt => opt.MapFrom(src => src.LotQuantities.Sum(x => Math.Round((1 - x.ReducedPayment ?? 1) * ((x.NonClaimable ?? false) ? 0 : 1) * x.Qty ?? 0 * x.ScheduleItem.SellRate ?? 0, 2)))).IncludeAllDerived()
                .ForMember(dest => dest.ApprovedByName, opt => opt.MapFrom(src => src.ApprovalBy == null ? "" : src.ApprovalBy.FirstName + " " + src.ApprovalBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.CloseoutByName, opt => opt.MapFrom(src => src.CloseOutBy == null ? "" : src.CloseOutBy.FirstName + " " + src.CloseOutBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.IsLatestStepAlert, opt => opt.MapFrom(src => src.Approval.IsLatestStepAlert)).IncludeAllDerived()
                .ForMember(dest => dest.IsApprovedToProceed, opt => opt.MapFrom(src =>
                    (src.ApprovalDate != null) ||
                    (src.Approval.IsApprovedToProceed ?? false) ||
                    (src.Approval.DateDirectlyApproved != null) ||
                    (src.Approval.IsCompleted ?? false))).IncludeAllDerived()
                .ForMember(dest => dest.IsApprovalComplete, opt => opt.MapFrom(src =>
                    (src.ApprovalDate != null) ||
                    (src.CloseOutDate != null) ||
                    (src.Approval.CloseOutDate != null) ||
                    (src.Approval.DateDirectlyApproved != null) ||
                    (src.Approval.IsCompleted ?? false))).IncludeAllDerived()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                    src.CloseOutDate != null ? "Closed Out" :
                    src.Approval == null ? (src.ApprovalDate != null ? "Manually Approved" : "Open") :
                    src.Approval.DateDirectlyApproved != null ? "Manually Approved" :
                    (src.Approval.IsCompleted ?? false) ? src.Approval.StatusLastStep :
                    src.Approval.CloseOutDate != null ? "Closed Out (Approval)" :
                    src.Approval.StatusLastStep ?? "Not started"
                    )).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalRemarks, opt => opt.MapFrom(src => src.ApprovalDetails ?? ""));

            CreateMap<Ncr, NcrDto>();
            CreateMap<Ncr, NcrTemplateDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ProjectNumber, opt => opt.MapFrom(src => src.Project.ContractNumber)).IncludeAllDerived()
                .ForMember(dest => dest.Lots, opt => opt.MapFrom(src => src.NcrLots.Select(x => x.Lot).OrderBy(x => x.LotNumber))).IncludeAllDerived();
            CreateMap<NcrDocument, NcrDocumentDto>()
                 .ForMember(dest => dest.NcrNo, opt => opt.MapFrom(src => src.Ncr.NcrNo)).IncludeAllDerived()
                 .ForMember(dest => dest.NcrDesc, opt => opt.MapFrom(src => src.Ncr.Description)).IncludeAllDerived()
                 .ForMember(dest => dest.DocNumber, opt => opt.MapFrom(src => src.CpDocument.DocumentNo)).IncludeAllDerived()
                 .ForMember(dest => dest.DocDescription, opt => opt.MapFrom(src => src.CpDocument.Description)).IncludeAllDerived();
            CreateMap<NcrLot, NcrLotDto>()
                .ForMember(dest => dest.NcrNo, opt => opt.MapFrom(src => src.Ncr.NcrNo)).IncludeAllDerived()
                .ForMember(dest => dest.NcrDesc, opt => opt.MapFrom(src => src.Ncr.Description)).IncludeAllDerived()
                .ForMember(dest => dest.NcrApprovalDate, opt => opt.MapFrom(src => src.Ncr.ApprovalDate)).IncludeAllDerived()
                .ForMember(dest => dest.NcrCloseOutDate, opt => opt.MapFrom(src => src.Ncr.CloseOutDate)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description)).IncludeAllDerived();
            CreateMap<NcrPunchlistItem, NcrPunchlistItemDto>()
                .ForMember(dest => dest.NcrNo, opt => opt.MapFrom(src => src.Ncr.NcrNo)).IncludeAllDerived()
                .ForMember(dest => dest.NcrDesc, opt => opt.MapFrom(src => src.Ncr.Description)).IncludeAllDerived()
                .ForMember(dest => dest.NcrApprovalDate, opt => opt.MapFrom(src => src.Ncr.ApprovalDate)).IncludeAllDerived()
                .ForMember(dest => dest.NcrCloseOutDate, opt => opt.MapFrom(src => src.Ncr.CloseOutDate)).IncludeAllDerived()
                .ForMember(dest => dest.PunchlistNo, opt => opt.MapFrom(src => src.PunchlistItem.Punchlist.PunchlistNo)).IncludeAllDerived()
                .ForMember(dest => dest.PunchlistName, opt => opt.MapFrom(src => src.PunchlistItem.Punchlist.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PunchlistItemNo, opt => opt.MapFrom(src => src.PunchlistItem.ItemNo)).IncludeAllDerived();
            CreateMap<NotificationItem, NotificationItemListDto>();
            CreateMap<NotificationItem, NotificationItemDto>();
            int? UserId = null;//Added to prevent intellisense throwing a hissy fit.
            CreateMap<Notification, NotificationListDto>()
                .ForMember(dest => dest.NotificationTypeId, opt => opt.MapFrom(src => UserId == null ? null : src.NotificationTos.Where(x => x.UserId == UserId).OrderByDescending(x => x.NotificationTypeId).Select(x => x.NotificationTypeId).FirstOrDefault())).IncludeAllDerived()
                .ForMember(dest => dest.DateRead, opt => opt.MapFrom(src => UserId == null ? null : src.NotificationTos.Where(x => x.UserId == UserId).OrderByDescending(x => x.NotificationTypeId).Select(x => x.DateRead).FirstOrDefault())).IncludeAllDerived()
                .ForMember(dest => dest.DateDismissed, opt => opt.MapFrom(src => UserId == null ? null : src.NotificationTos.Where(x => x.UserId == UserId).OrderByDescending(x => x.NotificationTypeId).Select(x => x.DateDismissed).FirstOrDefault())).IncludeAllDerived()
                .ForMember(dest => dest.NoticeByName, opt => opt.MapFrom(src => src.NoticeBy.FirstName + " " + src.NoticeBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ItemCount, opt => opt.MapFrom(src => src.NotificationItems.Count)).IncludeAllDerived()
                .ForMember(dest => dest.ItemCount_Actioned, opt => opt.MapFrom(src => src.NotificationItems.Where(ni => ni.ActionDate != null).Count())).IncludeAllDerived()
                ;
            CreateMap<Notification, NotificationDto>();
            CreateMap<NotificationTo, NotificationToDto>();
            CreateMap<NotificationEmail, NotificationEmailDto>()
                .ForMember(dest => dest.EmailDate, opt => opt.MapFrom(src => src.EmailLog == null ? null : src.EmailLog.DateEmailed)).IncludeAllDerived()
                .ForMember(dest => dest.EmailLogNo, opt => opt.MapFrom(src => src.EmailLog == null ? null : src.EmailLog.EmailLogNo)).IncludeAllDerived()
                .ForMember(dest => dest.NotificationNo, opt => opt.MapFrom(src => src.Notification.NotificationNo)).IncludeAllDerived()
                .ForMember(dest => dest.NoticeDate, opt => opt.MapFrom(src => src.Notification.NoticeDate)).IncludeAllDerived();
            CreateMap<Notification, NotificationEditDto>()
                .ForMember(dest => dest.NotificationTos, opt => opt.MapFrom(src => src.NotificationTos)).IncludeAllDerived()
                .ForMember(dest => dest.NotificationItems, opt => opt.MapFrom(src => src.NotificationItems)).IncludeAllDerived();

            if (!IsDesktop) CreateMap<Photo, PhotoListDto>()
                    .ForMember(dest => dest.PhotoDatePart, opt => opt.MapFrom(src => src.PhotoDate == null ? src.PhotoDate : src.PhotoDate.Value.Date)).IncludeAllDerived()
                    .ForMember(dest => dest.PhotoNo, opt => opt.MapFrom(src => src.PhotoNo)).IncludeAllDerived();
            CreateMap<Photo, PhotoDto>();
            CreateMap<PhotoApproval, PhotoApprovalDto>()
                .ForMember(dest => dest.PhotoDescription, opt => opt.MapFrom(src => src.Photo.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.Approval.ApprovalNo)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalSubjectHtml, opt => opt.MapFrom(src => src.Approval.SubjectHtml)).IncludeAllDerived()
                .ForMember(dest => dest.PhotoNo, opt => opt.MapFrom(src => src.Photo.PhotoNo)).IncludeAllDerived();
            CreateMap<Photo, PhotoTemplateDto>();
            CreateMap<PhotoLot, PhotoLotDto>()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.LotDesc, opt => opt.MapFrom(src => src.Lot.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PhotoDescription, opt => opt.MapFrom(src => src.Photo.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PhotoNo, opt => opt.MapFrom(src => src.Photo.PhotoNo)).IncludeAllDerived();
            CreateMap<PhotoIncident, PhotoIncidentDto>()
                .ForMember(dest => dest.IncidentDescHtml, opt => opt.MapFrom(src => src.Incident.DescriptionHtml))
                .ForMember(dest => dest.PhotoDescription, opt => opt.MapFrom(src => src.Photo.Description))
                .ForMember(dest => dest.IncidentNo, opt => opt.MapFrom(src => src.Incident.IncidentNo))
                .ForMember(dest => dest.PhotoNo, opt => opt.MapFrom(src => src.Photo.PhotoNo));
            CreateMap<PhotoChecklistItem, PhotoChecklistItemDto>()
                .ForMember(dest => dest.LotItpId, opt => opt.MapFrom(src => src.LotItpDetail == null ? null : src.LotItpDetail.LotItpId)).IncludeAllDerived()
                .ForMember(dest => dest.ChecklistLineDesc, opt => opt.MapFrom(src => src.LotItpDetail == null ? null : src.LotItpDetail.LotItp.Lot.LotNumber ?? "" + ": " + src.LotItpDetail.LotItp.Itp.Description ?? "No ITP Link")).IncludeAllDerived()
                .ForMember(dest => dest.PhotoDescription, opt => opt.MapFrom(src => src.Photo.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PhotoNo, opt => opt.MapFrom(src => src.Photo.PhotoNo)).IncludeAllDerived();

            CreateMap<PhotoPunchListItem, PhotoPunchlistItemDto>()
                .ForMember(dest => dest.PunchlistNo, opt => opt.MapFrom(src => src.PunchlistItem.Punchlist.PunchlistNo)).IncludeAllDerived()
                .ForMember(dest => dest.PunchlistName, opt => opt.MapFrom(src => src.PunchlistItem.Punchlist.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PunchlistItemNo, opt => opt.MapFrom(src => src.PunchlistItem.ItemNo)).IncludeAllDerived()
                .ForMember(dest => dest.PhotoDescription, opt => opt.MapFrom(src => src.Photo.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PhotoNo, opt => opt.MapFrom(src => src.Photo.PhotoNo)).IncludeAllDerived();
            CreateMap<PhotoVariation, PhotoVariationDto>()
                .ForMember(dest => dest.VrnNumber, opt => opt.MapFrom(src => src.Variation.VariationNo)).IncludeAllDerived()
                .ForMember(dest => dest.VrnDesc, opt => opt.MapFrom(src => src.Variation.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PhotoDescription, opt => opt.MapFrom(src => src.Photo.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PhotoNo, opt => opt.MapFrom(src => src.Photo.PhotoNo)).IncludeAllDerived();
            CreateMap<PhotoNcr, PhotoNcrDto>()
                .ForMember(dest => dest.NcrNo, opt => opt.MapFrom(src => src.Ncr.NcrNo)).IncludeAllDerived()
                .ForMember(dest => dest.NcrDesc, opt => opt.MapFrom(src => src.Ncr.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PhotoDescription, opt => opt.MapFrom(src => src.Photo.Description)).IncludeAllDerived()
                .ForMember(dest => dest.PhotoNo, opt => opt.MapFrom(src => src.Photo.PhotoNo)).IncludeAllDerived();
            CreateMap<ProgressClaimDetail, ProgressClaimDetailDto>()
                .ForMember(dest => dest.DjcTotal, opt => opt.MapFrom(src => Math.Round((src.DjcRate ?? 0) * (src.QtyScheduled ?? 0), 2))).IncludeAllDerived()
                .ForMember(dest => dest.SellTotal, opt => opt.MapFrom(src => Math.Round((src.SellRate ?? 0) * (src.QtyScheduled ?? 0), 2))).IncludeAllDerived(); CreateMap<ProgressClaimVersion_add, ProgressClaimVersion>();
            CreateMap<ProgressClaimVersion, ProgressClaimVersionDto>()
                .ForMember(dest => dest.ClaimToDate, opt => opt.MapFrom(src => src.ProgressClaimDetails.Count == 0 ? 0 : src.ProgressClaimDetails.Sum(y => Math.Round(((y.IsOverhead ?? false) ? 0 : 1) * (y.SellRate ?? 0) * (y.QtyClaimed ?? 0), 2)))).IncludeAllDerived()
                .ForMember(dest => dest.BudgetClaimed, opt => opt.MapFrom(src => src.ProgressClaimDetails.Count == 0 ? 0 : src.ProgressClaimDetails.Sum(y => Math.Round((y.DjcRate ?? 0) * (y.QtyClaimed ?? 0), 2)))).IncludeAllDerived()
                .ForMember(dest => dest.CertifiedValue, opt => opt.MapFrom(src => src.ProgressClaimDetails.Count == 0 ? 0 : src.ProgressClaimDetails.Sum(y => Math.Round(((y.IsOverhead ?? false) ? 0 : 1) * ((y.IsVariableRate ?? false) ? (y.SellRateCert ?? 0) : (y.SellRate ?? 0)) * (y.QtyCertified ?? 0), 2)))).IncludeAllDerived()
                .ForMember(dest => dest.OverUnder, opt => opt.MapFrom(src => src.ProgressClaimDetails.Count == 0 ? 0 : src.ProgressClaimDetails.Sum(y => Math.Round(((y.IsOverhead ?? false) ? 0 : 1) * (y.SellRate ?? 0) * (y.QtyOverUnder ?? 0), 2)))).IncludeAllDerived()
                .ForMember(dest => dest.OverUnderBudget, opt => opt.MapFrom(src => src.ProgressClaimDetails.Count == 0 ? 0 : src.ProgressClaimDetails.Sum(y => Math.Round((y.DjcRate ?? 0) * (y.QtyOverUnder ?? 0), 2)))).IncludeAllDerived()
                .ForMember(dest => dest.AtCompletion, opt => opt.MapFrom(src => src.ProgressClaimDetails.Count == 0 ? 0 : src.ProgressClaimDetails.Sum(y => Math.Round(((y.IsOverhead ?? false) ? 0 : 1) * ((y.IsVariableRate ?? false) ? (y.SellRateAtComp ?? 0) : (y.SellRate ?? 0)) * (y.QtyAtCompl ?? 0), 2)))).IncludeAllDerived()
                .ForMember(dest => dest.BudgetAtCompletion, opt => opt.MapFrom(src => src.ProgressClaimDetails.Count == 0 ? 0 : src.ProgressClaimDetails.Sum(y => Math.Round(((y.IsVariableRate ?? false) ? (y.DjcRateAtComp ?? 0) : (y.DjcRate ?? 0)) * (y.QtyAtCompl ?? 0), 2)))).IncludeAllDerived();
            CreateMap<ProgressClaimSnapshot, ProgressClaimSnapshotDto>()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleNumber, opt => opt.MapFrom(src => src.ScheduleItem.ScheduleNumber)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleDescription, opt => opt.MapFrom(src => src.ScheduleItem.Description)).IncludeAllDerived()
                .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description)).IncludeAllDerived()
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.ScheduleItem.Unit)).IncludeAllDerived();
            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.ProjectNumberAndName, opt => opt.MapFrom(src => src.ContractNumber == null ? src.Description : src.ContractNumber + ": " + src.Description)).IncludeAllDerived();
            CreateMap<Project, ProjectExtDto>();
            CreateMap<ProjectUser, ProjectUserDto>();
            CreateMap<ProjectReport, ProjectReportExportDto>();

            CreateMap<PurchaseOrder, PurchaseOrderListDto>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.SupplierName)).IncludeAllDerived()
                .ForMember(dest => dest.RaisedByName, opt => opt.MapFrom(src => src.RaisedBy.FirstName + " " + src.RaisedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.PoValue, opt => opt.MapFrom(src => src.PurchaseOrderDetails.Count == 0 ? 0 : Math.Round(src.PurchaseOrderDetails.Sum(x => (x.Qty ?? 0) * (x.Rate ?? 0)), 2))).IncludeAllDerived()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                    src.ApprovedDate != null ? "Approved" :
                    src.Approval == null ? "Not requested" :
                    src.Approval.CloseOutDate != null ? "Closed Out (Approval)" :
                    src.Approval.StatusLastStep ?? "Not started"
                    )).IncludeAllDerived();
            CreateMap<PurchaseOrder, PurchaseOrderBaseDto>()
                .ForMember(dest => dest.SupplierContact, opt => opt.MapFrom(scr => scr.SupplierContact)).IncludeAllDerived()
                .ForMember(dest => dest.TotalInvoiced, opt => opt.MapFrom(src => src.Invoices.Count == 0 ? 0m : Math.Round(src.Invoices.Sum(x => x.Amount ?? 0), 2))).IncludeAllDerived()
                .ForMember(dest => dest.TotalReceipted, opt => opt.MapFrom(src => (src.PurchaseOrderDetails == null || src.PurchaseOrderDetails.Count == 0) ? 0m : src.PurchaseOrderDetails.SelectMany(x => x.ReceiptDetails).Sum(rd => (rd == null || rd.PurchaseOrderDetail == null) ? 0 : Math.Round((rd.Qty ?? 0) * (rd.PurchaseOrderDetail.Rate ?? 0), 2)))).IncludeAllDerived()
                .ForMember(dest => dest.ApprovedByName, opt => opt.MapFrom(src => src.ApprovedBy == null ? "" : src.ApprovedBy.FirstName + " " + src.ApprovedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.PoContactName, opt => opt.MapFrom(src => src.PoContact == null ? "" : src.PoContact.FirstName + " " + src.PoContact.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.IsComplete, opt => opt.MapFrom(src => src.IsComplete == null ? false : src.IsComplete)).IncludeAllDerived();
            CreateMap<PurchaseOrder, PurchaseOrderDto>()
                .ForMember(dest => dest.TotalDaycost, opt => opt.MapFrom(src => src.Receipts.Count == 0 ? 0m : src.Receipts.SelectMany(x => x.DayCosts).Sum(rd => Math.Round((rd.Qty ?? 0) * (rd.Rate ?? 0), 2)))).IncludeAllDerived()
                .ForMember(dest => dest.PoValueDisplay, opt => opt.MapFrom(src => src.PurchaseOrderDetails.Where(x => !(x.IsRateOnly ?? false)).Count() == 0 ? 0m : src.PurchaseOrderDetails.Where(x => !(x.IsRateOnly ?? false)).Sum(x => Math.Round((x.Qty ?? 0) * (x.Rate ?? 0), 2)))).IncludeAllDerived();
            CreateMap<PurchaseOrder, PurchaseOrderTemplateDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ProjectNumber, opt => opt.MapFrom(src => src.Project.ContractNumber)).IncludeAllDerived()
                .ForMember(dest => dest.PurchaseOrderDetailsOrdered, opt => opt.MapFrom(src => src.PurchaseOrderDetails.OrderBy(x => x.ItemNumber))).IncludeAllDerived();
            CreateMap<PoEmail, PoEmailDto>()
                .ForMember(dest => dest.EmailDate, opt => opt.MapFrom(src => src.EmailLog.DateEmailed))
                .ForMember(dest => dest.FullPoDesc, opt => opt.MapFrom(src => src.PurchaseOrder == null ? "" : src.PurchaseOrder.PoNumber + ": " + src.PurchaseOrder.Supplier.SupplierName)).IncludeAllDerived()
                .ForMember(dest => dest.EmailLogNo, opt => opt.MapFrom(src => src.EmailLog.EmailLogNo)).IncludeAllDerived();
            if (!IsCe) CreateMap<PurchaseOrderDetail, PurchaseOrderDetailDto>()
                .ForMember(dest => dest.QtyReceipted, opt => opt.MapFrom(src => src.ReceiptDetails.Count == 0 ? 0m : src.ReceiptDetails.Sum(x => x.Qty ?? 0))).IncludeAllDerived();
            CreateMap<PurchaseOrderDetail, PurchaseOrderDetailTemplateDto>();

            CreateMap<Receipt, ReceiptDto>()
                .ForMember(dest => dest.TotalReceipted, opt => opt.MapFrom(src => src.ReceiptDetails.Count == 0 ? 0m : src.ReceiptDetails.Sum(x => Math.Round((x.Qty ?? 0) * (x.PurchaseOrderDetail.Rate ?? 0), 2)))).IncludeAllDerived()
                .ForMember(dest => dest.TotalDaycost, opt => opt.MapFrom(src => src.DayCosts.Count == 0 ? 0 : src.DayCosts.Sum(x => Math.Round((x.Qty ?? 0) * (x.Rate ?? 0), 2)))).IncludeAllDerived();
            CreateMap<ReportPeriod, ReportPeriodDto>();
            CreateMap<Resource, ResourceDto>()
                .ForMember(dest => dest.PurchaseOrderDetailId, opt => opt.MapFrom(src => src.PurchaseOrderDetailId)).IncludeAllDerived();
            CreateMap<cpModel.Models.Revision, RevisionDto>();

            CreateMap<UserRole, UserRoleReportDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName)).IncludeAllDerived()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email)).IncludeAllDerived()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.User.Company)).IncludeAllDerived()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName)).IncludeAllDerived()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId)).IncludeAllDerived()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ProjectNumber, opt => opt.MapFrom(src => src.Project.ContractNumber)).IncludeAllDerived()
                .ForMember(dest => dest.PoApprovalLimit, opt => opt.MapFrom(src => src.Role.PoApprovalLimit)).IncludeAllDerived()
                .ForMember(dest => dest.InvoiceApprovalLimit, opt => opt.MapFrom(src => src.Role.InvoiceApprovalLimit)).IncludeAllDerived()
                .ForMember(dest => dest.SubscriptionRoleType, opt => opt.MapFrom(src => src.Role.RolePermissions.Any(x => (x.Allowed ?? false) &&
                (x.AccessKey == (int)PermissionAccessEnum.Add || x.AccessKey == (int)PermissionAccessEnum.Edit || x.AccessKey == (int)PermissionAccessEnum.Admin_Delete)) ? SubscriptionRoleTypeEnum.Full : SubscriptionRoleTypeEnum.Associate));

            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.SubscriptionRoleType, opt => opt.MapFrom(src => src.RolePermissions.Any(x => (x.Allowed ?? false) &&
                (x.AccessKey == (int)PermissionAccessEnum.Add || x.AccessKey == (int)PermissionAccessEnum.Edit || x.AccessKey == (int)PermissionAccessEnum.Admin_Delete)) ? SubscriptionRoleTypeEnum.Full : SubscriptionRoleTypeEnum.Associate));
            CreateMap<RolePermission, RolePermissionDto>();
            CreateMap<Subscriber, SubscriptionDto>();
            CreateMap<SchedCostCode, SchedCostCodeDto>()
                .ForMember(dest => dest.CostCodeName, opt => opt.MapFrom(src => src.CostCode.CostCodeName)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleNo, opt => opt.MapFrom(src => src.ScheduleItem.ScheduleNumber)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleDescription, opt => opt.MapFrom(src => src.ScheduleItem.Description)).IncludeAllDerived()
                .ForMember(dest => dest.CostCodeDescription, opt => opt.MapFrom(src => src.CostCode.Description)).IncludeAllDerived();

            if (!IsDesktop) CreateMap<ScheduleItem, ScheduleFlatListDto>()
                .ForMember(dest => dest.DjcTotal, opt => opt.MapFrom(src => Math.Round((src.DjcRate ?? 0) * (src.QtyScheduled ?? 0), 2))).IncludeAllDerived()
                .ForMember(dest => dest.SellTotal, opt => opt.MapFrom(src => Math.Round((src.SellRate ?? 0) * (src.QtyScheduled ?? 0), 2))).IncludeAllDerived()
                .ForMember(dest => dest.IsHeading, opt => opt.MapFrom(src => src.QtyScheduled == null && src.SellRate == null)).IncludeAllDerived()
                .ForMember(dest => dest.LotQtyTotal, opt => opt.MapFrom(src => src.LotQuantities.Sum(x => x.Qty ?? 0))).IncludeAllDerived()
                .ForMember(dest => dest.LotQtyRemaining, opt => opt.MapFrom(src => (src.QtyScheduled ?? 0) - src.LotQuantities.Sum(x => x.Qty ?? 0))).IncludeAllDerived();
            CreateMap<ScheduleItem, ScheduleFlatDto>();
            CreateMap<ScheduleItem, ScheduleItemDto>()
                .ForMember(dest => dest.IsHeading, opt => opt.MapFrom(src => src.QtyScheduled == null && src.SellRate == null)).IncludeAllDerived();
            CreateMap<ScheduleItem, ScheduleItemListDto>();
            CreateMap<SiteDiary, SiteDiaryListDto>()
                .ForMember(dest => dest.DiaryByName, opt => opt.MapFrom(src => src.DiaryBy == null ? "" : src.DiaryBy.FirstName + " " + src.DiaryBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ReviewedByName, opt => opt.MapFrom(src => src.ReviewedBy == null ? "" : src.ReviewedBy.FirstName + " " + src.ReviewedBy.LastName)).IncludeAllDerived();
            CreateMap<SiteDiary, SiteDiaryTemplateDto>()
                 .ForMember(dest => dest.DiaryByName, opt => opt.MapFrom(src => src.DiaryBy == null ? "" : src.DiaryBy.FirstName + " " + src.DiaryBy.LastName)).IncludeAllDerived()
                 .ForMember(dest => dest.ReviewedByName, opt => opt.MapFrom(src => src.ReviewedBy == null ? "" : src.ReviewedBy.FirstName + " " + src.ReviewedBy.LastName)).IncludeAllDerived();
            CreateMap<SiteDiary, SiteDiaryDto>();
            CreateMap<SiteDiary, SiteDiaryReportDto>();
            CreateMap<SiteDiaryCost, SiteDiaryCostDto>()
                .ForMember(dest => dest.DiaryDate, opt => opt.MapFrom(src => src.SiteDiary.DiaryDate)).IncludeAllDerived()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => (src.Rate ?? 0) * (src.Qty ?? 0))).IncludeAllDerived()
                .ForMember(dest => dest.ResourceName, opt => opt.MapFrom(src => src.Resource.ResourceName)).IncludeAllDerived()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.SupplierName)).IncludeAllDerived();
            CreateMap<SiteDiaryCost, SiteDiaryCostReportDto>();
            CreateMap<SiteDiaryCostCode, SiteDiaryCostCodeDto>()
                .ForMember(dest => dest.CostCodeName, opt => opt.MapFrom(src => src.CostCode.CostCodeName));
            CreateMap<Subcontractor, SubcontractorLookupDto>();
            CreateMap<SubcontractorUser, SubcontractorUserDto>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User == null ? "" : src.User.FirstName + " " + src.User.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.SubcontractorName, opt => opt.MapFrom(src => src.Subcontractor.SubcontractorName)).IncludeAllDerived();
            CreateMap<SubcontractorLot, SubcontractorLotDto>()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.SubcontractorName, opt => opt.MapFrom(src => src.Subcontractor.SubcontractorName)).IncludeAllDerived();
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierLink, SupplierLinkDto>();
            CreateMap<Supplier, SupplierListDto>();
            CreateMap<SupplierDivision, SupplierDivisionDto>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.SupplierName)).IncludeAllDerived()
                .ForMember(dest => dest.DivisionName, opt => opt.MapFrom(src => src.Division.DivisionName)).IncludeAllDerived();

            CreateMap<SurveyRequest, SurveyRequestListDto>()
             .ForMember(dest => dest.HasDoc, opt => opt.MapFrom(src => src.FsSurveys.Any())).IncludeAllDerived()
             .ForMember(dest => dest.RequestByName, opt => opt.MapFrom(src => src.RequestBy == null ? "" :
                src.RequestBy.FirstName + " " + src.RequestBy.LastName)).IncludeAllDerived()
             .ForMember(dest => dest.RequestToName, opt => opt.MapFrom(src => src.RequestTo == null ? "" :
                src.RequestTo.FirstName + " " + src.RequestTo.LastName)).IncludeAllDerived()
             .ForMember(dest => dest.CompleteByName, opt => opt.MapFrom(src => src.User_MarkedCompletedBy == null ? "" :
                src.User_MarkedCompletedBy.FirstName + " " + src.User_MarkedCompletedBy.LastName)).IncludeAllDerived()
             .ForMember(dest => dest.IsSurveyComplete, opt => opt.MapFrom(src => src.DateCompleted != null)).IncludeAllDerived();
             //.ForMember(dest => dest.SurveyTypeName, opt => opt.MapFrom(src => ((SurveyTypeEnum)src.SurveyTypeId).ToString().Replace("_", " ")));

            CreateMap<SurveyRequest, SurveyRequestDto>();

            CreateMap<SurveyRequest, SurveyRequestLookupDto>();
            CreateMap<SurveyRequest, SurveyReportDto>()
                .ForMember(dest => dest.MarkedCompletedByName, opt => opt.MapFrom(src => src.MarkedCompletedBy == null ? "" :
                src.User_MarkedCompletedBy.FirstName + " " + src.User_MarkedCompletedBy.LastName)).IncludeAllDerived();
            CreateMap<SurveyRequest, SurveyRegisterReportDto>()
                 .ForMember(dest => dest.CompleteByName, opt => opt.MapFrom(src => src.MarkedCompletedBy == null ? "" :
                 src.User_MarkedCompletedBy.FirstName + " " + src.User_MarkedCompletedBy.LastName)).IncludeAllDerived();
            CreateMap<SurveyRequest, SurveyResultSetsReportDto>();
            CreateMap<SurveyResultSet, SurveyResultSetReportDto>();
            CreateMap<SurveyChainage, SurveyChainageDto>();
            CreateMap<SurveyChainage, SurveyChainageReportDto>()
                .ForMember(dest => dest.ControlLineName, opt => opt.MapFrom(src => src.ControlLine == null ? "" : src.ControlLine.ControlLineName)).IncludeAllDerived();
            CreateMap<SurveyResult, SurveyResultReportDto>();

            CreateMap<LotSurvey, LotSurveyDto>()
                .ForMember(dest => dest.SurveyLotId, opt => opt.MapFrom(src => src.LotSurveyId))
                .ForMember(dest => dest.SrNumber, opt => opt.MapFrom(src => src.SurveyRequest.SrNumber)).IncludeAllDerived()
                .ForMember(dest => dest.SurveyDesc, opt => opt.MapFrom(src => src.SurveyRequest.Description)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description)).IncludeAllDerived();
            CreateMap<LotSurvey, LotBasicReportDto>();

            CreateMap<ApprovalSurvey, ApprovalSurveyDto>()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.Approval.ApprovalNo)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalSubjectHtml, opt => opt.MapFrom(src => src.Approval.SubjectHtml)).IncludeAllDerived()
                .ForMember(dest => dest.SrNumber, opt => opt.MapFrom(src => src.SurveyRequest.SrNumber)).IncludeAllDerived()
                .ForMember(dest => dest.SurveyDescription, opt => opt.MapFrom(src => src.SurveyRequest.Description))
                .ForMember(dest => dest.ApprovalIsLatestStepAlert, opt => opt.MapFrom(src => src.Approval.IsLatestStepAlert)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalIsApprovedToProceed, opt => opt.MapFrom(src => src.Approval.IsApprovedToProceed)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalIsCompleted, opt => opt.MapFrom(src => src.Approval.IsCompleted)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalStatus, opt => opt.MapFrom(src => src.Approval.Status)).IncludeAllDerived()
                .ForMember(dest => dest.SurveyId, opt => opt.MapFrom(src => src.SurveyRequestId));

            CreateMap<SurveyResultSet, SurveyResultSetDto>()
                .ForMember(dest => dest.SrNumber, opt => opt.MapFrom(src => src.SurveyRequest.SrNumber)).IncludeAllDerived()
                .ForMember(dest => dest.SurveyDesc, opt => opt.MapFrom(src => src.SurveyRequest.Description));
            CreateMap<SurveyResult, SurveyResultDto>()
                .ForMember(dest => dest.SurveyResultSetId, opt => opt.MapFrom(src => src.SurveyResultSetId)).IncludeAllDerived();
            CreateMap<SurveyResultDto, SurveyResult>()
                .ForMember(dest => dest.SurveyResultSetId, opt => opt.MapFrom(src => src.SurveyResultSetId)).IncludeAllDerived();
            CreateMap<SurveyResult, SurveyResultListDto>();
            CreateMap<SurveyEmail, SurveyEmailDto>()
                .ForMember(dest => dest.EmailDate, opt => opt.MapFrom(src => src.EmailLog == null ? null : src.EmailLog.DateEmailed)).IncludeAllDerived()
                .ForMember(dest => dest.EmailLogNo, opt => opt.MapFrom(src => src.EmailLog == null ? null : src.EmailLog.EmailLogNo)).IncludeAllDerived()
                .ForMember(dest => dest.SrNumber, opt => opt.MapFrom(src => src.SurveyRequest.SrNumber)).IncludeAllDerived()
                .ForMember(dest => dest.SurveyDescription, opt => opt.MapFrom(src => src.SurveyRequest.Description)).IncludeAllDerived()
                .ForMember(dest => dest.DateRequest, opt => opt.MapFrom(src => src.SurveyRequest.DateRequest)).IncludeAllDerived();

            CreateMap<SystemProjectControl, ProjectControlDto>();
            CreateMap<SystemUserControl, SystemUserControlDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User == null ? "" : src.User.FirstName + " " + src.User.LastName)).IncludeAllDerived();
            CreateMap<SystemUserControl, SystemUserNotificationDto>();

            if (!IsApi) CreateMap<TagCode, TagCodeDto>();
            CreateMap<Template, TemplateDto>();
            CreateMap<Template, TemplateExportDto>();

            if (!IsApi) CreateMap<TestMethod, TestMethodDto>();
            CreateMap<TestReqEmail, TestReqEmailDto>()
                .ForMember(dest => dest.TestReqLot, opt => opt.MapFrom(src => src.TestRequest.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.EmailDate, opt => opt.MapFrom(src => src.EmailLog == null ? null : src.EmailLog.DateEmailed)).IncludeAllDerived()
                .ForMember(dest => dest.EmailLogNo, opt => opt.MapFrom(src => src.EmailLog == null ? null : src.EmailLog.EmailLogNo)).IncludeAllDerived()
                .ForMember(dest => dest.TestReqNo, opt => opt.MapFrom(src => src.TestRequest.TestRequestNo)).IncludeAllDerived()
                .ForMember(dest => dest.TestReqDate, opt => opt.MapFrom(src => src.TestRequest.DateRequest)).IncludeAllDerived();
            CreateMap<TestRequest, TestRequestBasicDto>()
                 .ForMember(dest => dest.RequestedByName, opt => opt.MapFrom(src => src.RequestedBy == null ? "" : src.RequestedBy.FirstName + " " + src.RequestedBy.LastName)).IncludeAllDerived()
                 .ForMember(dest => dest.RequestToName, opt => opt.MapFrom(src => src.TestRequestTo == null ? "" : src.TestRequestTo.FirstName + " " + src.TestRequestTo.LastName)).IncludeAllDerived()
                 .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                 .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description)).IncludeAllDerived();
            CreateMap<TestRequest, TestRequestForSummaryDto>()
                 .ForMember(dest => dest.UploadCount, opt => opt.MapFrom(src => src.FsTestReqs.Count)).IncludeAllDerived()
                 .ForMember(dest => dest.LatestUploadDate, opt => opt.MapFrom(src => src.FsTestReqs.OrderByDescending(x => x.CreatedOn).Select(x => x.CreatedOn).FirstOrDefault())).IncludeAllDerived();
            CreateMap<TestRequest, TestRequestListDto>()
                .ForMember(dest => dest.ControlLineName, opt => opt.MapFrom(src => src.ControlLine == null ? "" : src.ControlLine.ControlLineName)).IncludeAllDerived()
                .ForMember(dest => dest.TestComplete, opt => opt.MapFrom(src => src.DateTestCompleted != null)).IncludeAllDerived()
                .ForMember(dest => dest.HasDoc, opt => opt.MapFrom(src => src.FsTestReqs.Any())).IncludeAllDerived()
                .ForMember(dest => dest.HasTest, opt => opt.MapFrom(src => src.TestRequestTests.Any())).IncludeAllDerived()
                .ForMember(dest => dest.UploadCount, opt => opt.MapFrom(src => src.FsTestReqs.Count)).IncludeAllDerived()
                .ForMember(dest => dest.LatestUploadDate, opt => opt.MapFrom(src => src.FsTestReqs.OrderByDescending(x => x.FileStoreDoc.FileDate).Select(x => x.FileStoreDoc.FileDate).FirstOrDefault())).IncludeAllDerived()
                .ForMember(dest => dest.LatestEmailDate, opt => opt.MapFrom(src => src.TestReqEmails.OrderByDescending(x => x.EmailLog.DateEmailed).Select(x => x.EmailLog.DateEmailed).FirstOrDefault())).IncludeAllDerived();
            CreateMap<TestRequest, TestRequestDto>()
                .ForMember(dest => dest.AllApproved, opt => opt.MapFrom(src => src.TestRequestTests.All(x => x.TestComplete.Value == true))).IncludeAllDerived()

                //.ForMember(dest => dest.TestCount, opt => opt.MapFrom(src => src.TestRequestTests == null ? 0 : src.TestRequestTests.Count()))
                //.ForMember(dest => dest.TestCountUnapp, opt => opt.MapFrom(src => src.TestRequestTests == null ? 0 : src.TestRequestTests.Where(x => x.TestComplete == null || x.TestComplete.Value != true).Count()))
                ;
            CreateMap<TestRequestTest, TestRequestTestDto>()
                .ForMember(dest => dest.ScheduleName, opt => opt.MapFrom(src => src.ScheduleItem == null ? "" : src.ScheduleItem.ScheduleNumber + ": " + src.ScheduleItem.Description)).IncludeAllDerived()
                .ForMember(dest => dest.TestRequestNo, opt => opt.MapFrom(src => src.TestRequest.TestRequestNo)).IncludeAllDerived()
                .ForMember(dest => dest.TestMethodName, opt => opt.MapFrom(src => src.TestMethod == null ? "" : src.TestMethod.TestNum + ": " + src.TestMethod.TestDescription)).IncludeAllDerived()
                .ForMember(dest => dest.ControlLineName, opt => opt.MapFrom(src => src.ControlLine.ControlLineName)).IncludeAllDerived();
            CreateMap<TestRequestTest, TestRequestTestResultDto>()
                .ForMember(dest => dest.TestRequestNo, opt => opt.MapFrom(src => src.TestRequest.TestRequestNo)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.TestRequest.Lot.LotNumber)).IncludeAllDerived();
            CreateMap<TestRequestTest, TestRequestTestForSummaryDto>();
            CreateMap<TestRequest, TestRequestWithGeometryDto>();
            CreateMap<TestRequest, TestRequestTemplateDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ProjectNumber, opt => opt.MapFrom(src => src.Project.ContractNumber)).IncludeAllDerived()
                .ForMember(dest => dest.FilestoreDocsOrdered, opt => opt.MapFrom(src => src.FsTestReqs.Select(x => x.FileStoreDoc).OrderByDescending(x => x.FileDate))).IncludeAllDerived()
                .ForMember(dest => dest.TestsOrdered, opt => opt.MapFrom(src => src.TestRequestTests.OrderBy(x => x.SampleId))).IncludeAllDerived();
            CreateMap<TestRequestProperty, TestRequestPropertyDto>();
            CreateMap<TestResult, TestRequestResultDto>()
                .ForMember(dest => dest.TestRequestNo, opt => opt.MapFrom(src => src.TestRequestTest.TestRequest.TestRequestNo)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.TestRequestTest.TestRequest.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.DateSampled, opt => opt.MapFrom(src => src.TestRequestTest.DateSampled.Value)).IncludeAllDerived()
                .ForMember(dest => dest.SampleNo, opt => opt.MapFrom(src => src.TestRequestTest.SampleId)).IncludeAllDerived()
                .ForMember(dest => dest.TestMethodId, opt => opt.MapFrom(src => src.TestRequestTest.TestMethodId)).IncludeAllDerived()
                .ForMember(dest => dest.TestRequestTestId, opt => opt.MapFrom(src => src.TestRequestTest.TestRequestTestId)).IncludeAllDerived();
            CreateMap<TestResult, TestResultDto>();
            CreateMap<TestResultField, TestResultFieldDto>();
            CreateMap<TestCoordinate, TestCoordinateDto>();
            CreateMap<TestPropertyGroup, TestPropertyGroupDto>();
            CreateMap<TestPropertyItem, TestPropertyItemDto>();
            CreateMap<Transmittal, TransmittalDto>();
            CreateMap<Transmittal, TransmittalReportDto>()
                .ForMember(dest => dest.TransmittalToInfo, opt => opt.MapFrom(src => src.User)).IncludeAllDerived();
            CreateMap<TransmittalItem, TransmittalItemDto>()
                .ForMember(dest => dest.DocumentNo, opt => opt.MapFrom(src => src.CpDocument.DocumentNo)).IncludeAllDerived()
                .ForMember(dest => dest.DocumentDesc, opt => opt.MapFrom(src => src.CpDocument.Description)).IncludeAllDerived()
                .ForMember(dest => dest.RevisionName, opt => opt.MapFrom(src => src.Revision.RevRef)).IncludeAllDerived();
            CreateMap<TransmittalItem, TransmittalItemReportDto>()
                .ForMember(dest => dest.RevisionDate, opt => opt.MapFrom(src => src.Revision.RevisionDate)).IncludeAllDerived()
                .ForMember(dest => dest.RevisionDescription, opt => opt.MapFrom(src => src.Revision.Description)).IncludeAllDerived();
            CreateMap<TransmittalEmail, TransmittalEmailDto>()
                .ForMember(dest => dest.EmailDate, opt => opt.MapFrom(src => src.EmailLog == null ? null : src.EmailLog.DateEmailed)).IncludeAllDerived()
                .ForMember(dest => dest.EmailLogNo, opt => opt.MapFrom(src => src.EmailLog == null ? null : src.EmailLog.EmailLogNo)).IncludeAllDerived()
                .ForMember(dest => dest.TransmittalNumber, opt => opt.MapFrom(src => src.Transmittal.TransmittalNo)).IncludeAllDerived();

            CreateMap<Unit, UnitLookupDto>();
            CreateMap<Unit, UnitDto>();
            CreateMap<User, UserReportDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)).IncludeAllDerived();
            if (!IsApi) CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)).IncludeAllDerived();
            CreateMap<User, UserFullDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)).IncludeAllDerived();
            CreateMap<User, UserExtDto>()
                 .ForMember(dest => dest.SubscriptionRoleType, opt => opt.MapFrom(src => src.UserRoles.Any(p => p.Role.RolePermissions.Any(perm => (perm.Allowed == null ? false : perm.Allowed.Value) && (perm.RegisterKey < 1000) && (perm.AccessKey == 2 || perm.AccessKey == 3 || perm.AccessKey == 4))) ? 2 : 1))
                 .ForMember(dest => dest.ProjectsCount, opt => opt.MapFrom(src => src.UserRoles.Select(y => y.Project).Where(x => x.InActive != true).Distinct().Count())).IncludeAllDerived();

            CreateMap<User, UserBasicDto>()
                .ForMember(dest => dest.FirstLast, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)).IncludeAllDerived();
            CreateMap<User, UserAddresseeTemplateDto>();
            CreateMap<User, UserPasswordResetTemplateDto>();
            CreateMap<User, ContactDto>()
                .ForMember(dest => dest.FirstLast, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)).IncludeAllDerived();
            if (!IsApi) CreateMap<User, ContactListDto>()
                .ForMember(dest => dest.IsUser, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Username))).IncludeAllDerived()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)).IncludeAllDerived();
            CreateMap<User, AddresseeDto>()
                .ForMember(dest => dest.FirstLast, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)).IncludeAllDerived();
            CreateMap<UserGroup, UserGroupDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group.GroupName)).IncludeAllDerived()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName)).IncludeAllDerived();
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRole, UserRolePermsDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName)).IncludeAllDerived()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName)).IncludeAllDerived();
            CreateMap<UserRole, UserRoleSubscriptionInfoDto>();
            CreateMap<Role, RoleSummaryDto>()
                .ForMember(dest => dest.ViewLimitedPermissionCount, opt => opt.MapFrom(src => src.RolePermissions.Where(x => x.AccessKey == (int)PermissionAccessEnum.View_Limited && (x.Allowed ?? false)).Count())).IncludeAllDerived()
                .ForMember(dest => dest.ViewPermissionCount, opt => opt.MapFrom(src => src.RolePermissions.Where(x => x.AccessKey == (int)PermissionAccessEnum.View && (x.Allowed ?? false)).Count())).IncludeAllDerived()
                .ForMember(dest => dest.AddPermissionCount, opt => opt.MapFrom(src => src.RolePermissions.Where(x => x.AccessKey == (int)PermissionAccessEnum.Add && (x.Allowed ?? false)).Count())).IncludeAllDerived()
                .ForMember(dest => dest.EditPermissionCount, opt => opt.MapFrom(src => src.RolePermissions.Where(x => x.AccessKey == (int)PermissionAccessEnum.Edit && (x.Allowed ?? false)).Count())).IncludeAllDerived()
                .ForMember(dest => dest.Admin_DeletePermissionCount, opt => opt.MapFrom(src => src.RolePermissions.Where(x => x.AccessKey == (int)PermissionAccessEnum.Admin_Delete && (x.Allowed ?? false)).Count())).IncludeAllDerived()
                .ForMember(dest => dest.AbsolutePermissionCount, opt => opt.MapFrom(src => src.RolePermissions.Where(x => x.AccessKey == (int)PermissionAccessEnum.Absolute && (x.Allowed ?? false)).Count())).IncludeAllDerived();
            CreateMap<UserInvite, UserInviteDto>()
                .ForMember(dest => dest.ProjectNumberAndName, opt => opt.MapFrom(src => src.Project.ContractNumber == null ? src.Project.Description : src.Project.ContractNumber + ": " + src.Project.Description)).IncludeAllDerived();
            CreateMap<UserInvite, UserInviteTemplateDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ProjectNumber, opt => opt.MapFrom(src => src.Project.ContractNumber)).IncludeAllDerived();

            CreateMap<Variation, VariationListDto>()
                .ForMember(dest => dest.VariationStatus, opt => opt.MapFrom((src => src.VrnWaypoints.OrderByDescending(x => x.WaypointDate).Select(wp => wp.VrnStatus.Description).FirstOrDefault()))).IncludeAllDerived()
                .ForMember(dest => dest.StatusDate, opt => opt.MapFrom((src => src.VrnWaypoints.OrderByDescending(x => x.WaypointDate).Select(wp => wp.WaypointDate).FirstOrDefault()))).IncludeAllDerived()
                .ForMember(dest => dest.HasEstimate, opt => opt.MapFrom(src => src.VariationEstimates.Count > 0)).IncludeAllDerived()
                .ForMember(dest => dest.SellTotalEstimate, opt => opt.MapFrom(src => src.VariationEstimates.Count == 0 ? 0 : src.VariationEstimates.Sum(x => x.SellTotal ?? 0))).IncludeAllDerived()
                .ForMember(dest => dest.RaisedByName, opt => opt.MapFrom((src => src.RaisedBy == null ? "" : src.RaisedBy.FirstName + " " + src.RaisedBy.LastName))).IncludeAllDerived();
            CreateMap<Variation, VariationDto>()
                .ForMember(dest => dest.DJCTotalEstimate, opt => opt.MapFrom(src => src.VariationEstimates.Count == 0 ? 0 : src.VariationEstimates.Sum(x => x.DjcTotal ?? 0))).IncludeAllDerived()
                .ForMember(dest => dest.DateIdentified, opt => opt.MapFrom(src => src.VrnWaypoints.Where(x => x.VrnStatusId == (int)VrnStatusEnum.Identified).Select(x => x.WaypointDate).FirstOrDefault())).IncludeAllDerived()
                .ForMember(dest => dest.DateNotified, opt => opt.MapFrom(src => src.VrnWaypoints.Where(x => x.VrnStatusId == (int)VrnStatusEnum.Notified).Select(x => x.WaypointDate).FirstOrDefault())).IncludeAllDerived()
                .ForMember(dest => dest.DateSubmitted, opt => opt.MapFrom(src => src.VrnWaypoints.Where(x => x.VrnStatusId == (int)VrnStatusEnum.Submitted).Select(x => x.WaypointDate).FirstOrDefault())).IncludeAllDerived()
                .ForMember(dest => dest.DateSubmitted, opt => opt.MapFrom(src => src.VrnWaypoints.Where(x => x.VrnStatusId == (int)VrnStatusEnum.Conditionally_Approved || x.VrnStatusId == (int)VrnStatusEnum.Approved || x.VrnStatusId == (int)VrnStatusEnum.Approved_In_Principle).Select(x => x.WaypointDate).FirstOrDefault())).IncludeAllDerived();
            CreateMap<Variation, VariationTemplateDto>();
            CreateMap<VariationLot, VariationLotDto>()
                .ForMember(dest => dest.FullLotDesc, opt => opt.MapFrom(src => src.Lot.LotNumber + ": " + src.Lot.Description)).IncludeAllDerived()
                .ForMember(dest => dest.FullVariationDesc, opt => opt.MapFrom(src => src.Variation == null ? "" : src.Variation.VariationNo + ": " + src.Variation.Description)).IncludeAllDerived();
            CreateMap<VrnInstruction, VrnInstructionDto>()
                .ForMember(dest => dest.VrnNumber, opt => opt.MapFrom(src => src.Variation.VariationNo)).IncludeAllDerived()
                .ForMember(dest => dest.VrnDesc, opt => opt.MapFrom(src => src.Variation.Description)).IncludeAllDerived()
                .ForMember(dest => dest.InstructionDescHtml, opt => opt.MapFrom(src => src.Instruction.DescriptionHtml)).IncludeAllDerived()
                .ForMember(dest => dest.InstructionNo, opt => opt.MapFrom(src => src.Instruction.InstructionNo)).IncludeAllDerived();
            CreateMap<VariationLot, VariationLotReportDto>()
                .ForMember(dest => dest.VarNo, opt => opt.MapFrom(src => src.Variation.Description)).IncludeAllDerived()
                .ForMember(dest => dest.VarDesc, opt => opt.MapFrom(src => src.Variation.VariationNo)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.LotDesc, opt => opt.MapFrom(src => src.Lot.Description)).IncludeAllDerived();
            CreateMap<VariationSchedule, VariationScheduleDto>()
                .ForMember(dest => dest.ScheduleDesc, opt => opt.MapFrom(src => src.ScheduleItem == null ? "" : string.IsNullOrEmpty(src.ScheduleItem.ScheduleNumber) ? src.ScheduleItem.Description : src.ScheduleItem.ScheduleNumber + ": " + src.ScheduleItem.Description))
                .ForMember(dest => dest.VariationDesc, opt => opt.MapFrom(src => src.Variation == null ? "" : src.Variation.VariationNo + ": " + src.Variation.Description));
            CreateMap<VrnStatus, VrnStatusDto>();
            CreateMap<VariationEstimate, VariationEstimateDto>();
            CreateMap<VrnWaypoint, VrnWaypointDto>()
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.VrnStatus.Description));

            CreateMap<Workflow, WorkflowDto>()
                .Ignore(x => x.WorkflowActions)
                .Ignore(x => x.WorkflowSteps)
                .Ignore(x => x.WorkflowLogs);
            CreateMap<WorkflowAction, WorkflowActionDto>().Ignore(x => x.WorkflowActionPoints).Ignore(x => x.WorkflowActionRoles)
                    .Ignore(x => x.WorkflowActionUsers);
            CreateMap<WorkflowAction, WorkflowUpdateActionDto>();
            CreateMap<WorkflowAction, WorkflowActionWithToStepDto>();
            CreateMap<WorkflowStep, WorkflowStepDto>();
            CreateMap<WorkflowStep, WorkflowUpdateStepDto>();
            CreateMap<WorkflowActionPoint, WorkflowActionPointDto>();
            CreateMap<WorkflowActionUser, WorkflowActionUserDto>()
                .ForMember(dest => dest.UserGuid, opt => opt.MapFrom(src => src.User.UniqueId)).IncludeAllDerived();
            CreateMap<WorkflowActionRole, WorkflowActionRoleDto>()
                    .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName)).IncludeAllDerived();
            CreateMap<WorkflowLog, WorkflowLogListDto>()
                    .ForMember(dest => dest.LogByName, opt => opt.MapFrom(src => src.User == null ? "" : src.User.FirstName + " " + src.User.LastName)).IncludeAllDerived()
                    .ForMember(dest => dest.StatusBefore, opt => opt.MapFrom(src => src.WorkflowAction.StepFrom.Text)).IncludeAllDerived()
                    .ForMember(dest => dest.StatusAfter, opt => opt.MapFrom(src => src.WorkflowStep.Text)).IncludeAllDerived()
                    .ForMember(dest => dest.IsPrivate, opt => opt.MapFrom(src => src.IsPrivate ?? false)).IncludeAllDerived()
                    .ForMember(dest => dest.ActionName, opt => opt.MapFrom(src => src.WorkflowAction.Text)).IncludeAllDerived();
            CreateMap<WorkflowLog, WorkflowLogDto>();
            CreateMap<WorkflowLog, WorkflowLogTemplateDto>();
            if (!IsApi) CreateMap<WorkType, WorkTypeDto>()
                .ForMember(dest => dest.HasScheduleLink, opt => opt.MapFrom(src => src.WorkSchedules.Count > 0));
            CreateMap<WorkSchedule, WorkScheduleDto>()
                .ForMember(dest => dest.WorkTypeName, opt => opt.MapFrom(src => src.WorkType.WorkTypeName)).IncludeAllDerived()
                .ForMember(dest => dest.WorkTypeDescription, opt => opt.MapFrom(src => src.WorkType.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleNo, opt => opt.MapFrom(src => src.ScheduleItem.ScheduleNumber)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleDesc, opt => opt.MapFrom(src => src.ScheduleItem.Description)).IncludeAllDerived();

            //Lookup
            CreateMap<Approval, ApprovalLookupDto>();
            CreateMap<ApprovalWorkflow, ApprovalWorkflowLookupDto>(); CreateMap<Atp, AtpLookupDto>();
            CreateMap<ContractNoticeTemplate, CnTemplateLookupDto>();
            CreateMap<ControlLine, ControlLineLookupDto>();
            CreateMap<CostCode, CostCodeLookupDto>();
            CreateMap<FileStoreDoc, FileStoreDocLookupDto>();
            CreateMap<Group, GroupLookupDto>();
            CreateMap<Itp, ItpLookupDto>();
            CreateMap<Lot, LotLookupDto>();
            CreateMap<Lot, LotChainageDto>();
            CreateMap<Ncr, NcrLookupDto>();
            CreateMap<Project, ProjectLookupDto>();
            CreateMap<Supplier, SupplierLookupDto>();
            CreateMap<Template, TemplateLookupDto>();
            CreateMap<TestMethod, TestMethodLookupDto>();
            CreateMap<TestPropertyGroup, TestPropertyGroupLookupDto>();
            CreateMap<TestRequest, TestRequestLookupDto>();
            CreateMap<Unit, UnitLookupDto>();
            CreateMap<Variation, VrnLookupDto>();
            CreateMap<WorkflowAction, WorkflowActionLookupDto>();
            CreateMap<WorkflowStep, WorkflowStepLookupDto>();
            CreateMap<WorkType, WorktypeLookupDto>();


            //Report
            CreateMap<Approval, ApprovalListReportDto>();
            CreateMap<Approval, ApprovalReportDto>();
            CreateMap<Approval, ApprovalLotItpDetailReportDto>()
                .ForMember(dest => dest.LotItpDetailId, opt => opt.MapFrom(src => src.LotItpDetailLinkId)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.ApprovalNo)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalSubjectHtml, opt => opt.MapFrom(src => src.SubjectHtml)).IncludeAllDerived()
                .ForMember(dest => dest.RequestDate, opt => opt.MapFrom(src => src.RequestDate)).IncludeAllDerived()
                .ForMember(dest => dest.DateLastStep, opt => opt.MapFrom(src => src.DateLastStep)).IncludeAllDerived()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)).IncludeAllDerived()
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted)).IncludeAllDerived();
            CreateMap<ApprovalLotItpDetail, ApprovalLotItpDetailReportDto>()
                .ForMember(dest => dest.ApprovalNo, opt => opt.MapFrom(src => src.Approval.ApprovalNo)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovalSubjectHtml, opt => opt.MapFrom(src => src.Approval.SubjectHtml)).IncludeAllDerived()
                .ForMember(dest => dest.RequestDate, opt => opt.MapFrom(src => src.Approval.RequestDate)).IncludeAllDerived()
                .ForMember(dest => dest.DateLastStep, opt => opt.MapFrom(src => src.Approval.DateLastStep)).IncludeAllDerived()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Approval.Status)).IncludeAllDerived()
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.Approval.IsCompleted)).IncludeAllDerived();
            CreateMap<Atp, AtpReportDto>()
                .ForMember(dest => dest.RequestedByPosition, opt => opt.MapFrom(src => src.RequestedBy == null ? "" : src.RequestedBy.Position)).IncludeAllDerived()
                .ForMember(dest => dest.RequestedByName, opt => opt.MapFrom(src => src.RequestedBy == null ? "" : src.RequestedBy.FirstName + " " + src.RequestedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.SentToPosition, opt => opt.MapFrom(src => src.SentTo == null ? "" : src.SentTo.Position)).IncludeAllDerived()
                .ForMember(dest => dest.SentToName, opt => opt.MapFrom(src => src.SentTo == null ? "" : src.SentTo.FirstName + " " + src.SentTo.LastName)).IncludeAllDerived();
            CreateMap<AtpLot, AtpLotReportDto>()
                .ForMember(dest => dest.ApprovedByName, opt => opt.MapFrom(src => src.ApprovalByUser == null ? "" : src.ApprovalByUser.FirstName + " " + src.ApprovalByUser.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.AtpNo, opt => opt.MapFrom(src => src.Atp == null ? null : src.Atp.AtpNo)).IncludeAllDerived()
                .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description)).IncludeAllDerived();
            CreateMap<AtpLot, AtpLotForConfReportDto>()
                .ForMember(dest => dest.AtpNo, opt => opt.MapFrom(src => src.Atp == null ? null : src.Atp.AtpNo)).IncludeAllDerived()
                .ForMember(dest => dest.ATPDate, opt => opt.MapFrom(src => src.Atp == null ? null : src.Atp.Datesub)).IncludeAllDerived()
                .ForMember(dest => dest.AtpDescription, opt => opt.MapFrom(src => src.Atp == null ? null : src.Atp.Description)).IncludeAllDerived();
            CreateMap<ApprovalLotItpDetail, LotItpDetailApprovalReportDto>();
            CreateMap<Itp, ItpReportDto>();
            CreateMap<ItpDetail, ItpDetailReportDto>();
            CreateMap<ItpTesting, ItpTestReportDto>();

            CreateMap<Instruction, InstructionReportDto>()
                .ForMember(dest => dest.ClosedOutName, opt => opt.MapFrom(src => src.ClosedOutBy == null ? "" : src.ClosedOutBy.FirstName + " " + src.ClosedOutBy.LastName)).IncludeAllDerived()
;

            CreateMap<Lot, LotBasicReportDto>()
                .ForMember(dest => dest.RpValue, opt => opt.MapFrom(src => src.LotQuantities.Sum(x => Math.Round((1 - x.ReducedPayment ?? 1) * ((x.NonClaimable ?? false) ? 0 : 1) * x.Qty ?? 0 * x.ScheduleItem.SellRate ?? 0, 2)))).IncludeAllDerived();
            CreateMap<Approval, LotConfApprovalReportDto>();
            CreateMap<Lot, LotDatesReportDto>();
            CreateMap<Lot, LotReportDto>()
                .ForMember(dest => dest.WorkTypeName, opt => opt.MapFrom(src => src.WorkType == null ? "" : src.WorkType.WorkTypeName)).IncludeAllDerived()
                .ForMember(dest => dest.AreaCodeName, opt => opt.MapFrom(src => src.AreaCode == null ? "" : src.AreaCode.AreaCodeName)).IncludeAllDerived()
                .ForMember(dest => dest.RaisedByName, opt => opt.MapFrom(src => src.RaisedBy == null ? "" : src.RaisedBy.FirstName + " " + src.RaisedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ConformedByName, opt => opt.MapFrom(src => src.ConformedBy == null ? "" : src.ConformedBy.FirstName + " " + src.ConformedBy.LastName)).IncludeAllDerived();
            CreateMap<Lot, LotSummaryReportDto>()
                .ForMember(dest => dest.NCRClosedCount, opt => opt.MapFrom(src => src.NcrLots.Where(x => x.Ncr.CloseOutDate != null).Count())).IncludeAllDerived()
                .ForMember(dest => dest.NCRAppCount, opt => opt.MapFrom(src => src.NcrLots.Where(x => x.Ncr.CloseOutDate == null && x.Ncr.ApprovalDate != null).Count())).IncludeAllDerived()
                .ForMember(dest => dest.NCRUnAppCount, opt => opt.MapFrom(src => src.NcrLots.Where(x => x.Ncr.CloseOutDate == null && x.Ncr.ApprovalDate == null).Count())).IncludeAllDerived()
                .ForMember(dest => dest.ATPInspCount, opt => opt.MapFrom(src => src.AtpLots.Count())).IncludeAllDerived()
                .ForMember(dest => dest.ATPInspUnAppCount, opt => opt.MapFrom(src => src.AtpLots.Where(x => x.DateApproved == null).Count())).IncludeAllDerived()
                .ForMember(dest => dest.QtyCount, opt => opt.MapFrom(src => src.LotQuantities.Count())).IncludeAllDerived()
                .ForMember(dest => dest.ZeroQtyCount, opt => opt.MapFrom(src => src.LotQuantities.Where(x => x.Qty == 0).Count())).IncludeAllDerived()
                .ForMember(dest => dest.TRCount, opt => opt.MapFrom(src => src.TestRequests.Count())).IncludeAllDerived()
                .ForMember(dest => dest.TRIncompleteCount, opt => opt.MapFrom(src => src.TestRequests.Where(x => x.DateTestCompleted == null).Count())).IncludeAllDerived();
            CreateMap<LotItp, ChecklistReportDto>()
                .ForMember(dest => dest.RaisedByName, opt => opt.MapFrom(src => src.RaisedBy == null ? "" : src.RaisedBy.FirstName + " " + src.RaisedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovedByName, opt => opt.MapFrom(src => src.ApprovedBy == null ? "" : src.ApprovedBy.FirstName + " " + src.ApprovedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ITPName, opt => opt.MapFrom(src => src.Itp == null ? "" : src.Itp.Description)).IncludeAllDerived();
            CreateMap<LotItp, LotItpReportDto>()
                .ForMember(dest => dest.DateWorkStarted, opt => opt.MapFrom(src => src.Lot.DateWorkSt)).IncludeAllDerived()
                .ForMember(dest => dest.DateLotOpened, opt => opt.MapFrom(src => src.Lot.DateOpen)).IncludeAllDerived()
                .ForMember(dest => dest.DateWorkEnded, opt => opt.MapFrom(src => src.Lot.DateWorkEnd)).IncludeAllDerived();
            CreateMap<LotItp, LotItpStatusReportDto>();
            CreateMap<LotItpDetail, LotItpDetailReportDto>()
                //.ForMember(dest => dest.LotNoDesc_ApprovalManual, opt => opt.MapFrom(src => src.ApprovalLot == null ? "" : src.ApprovalLot.LotNumber + ": " + src.ApprovalLot.Description)).IncludeAllDerived()
                .ForMember(dest => dest.AtpNo, opt => opt.MapFrom(src => src.ApprovalAtp.AtpNo)).IncludeAllDerived()
                .ForMember(dest => dest.AtpDesc, opt => opt.MapFrom(src => src.ApprovalAtp.Description)).IncludeAllDerived();
            CreateMap<LotItpDetail, LotItpDetailStatusReportDto>();
            CreateMap<LotItpTest, LotItpTestReportDto>();
            CreateMap<LotSurvey, LotSurveyReportDto>();
            CreateMap<LotQuantity, LotQuantityReportDto>()
                .ForMember(dest => dest.ScheduleOrderId, opt => opt.MapFrom(src => src.ScheduleItem == null ? 0 : src.ScheduleItem.OrderId)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleNo, opt => opt.MapFrom(src => src.ScheduleItem.ScheduleNumber)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleDescription, opt => opt.MapFrom(src => src.ScheduleItem.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleSellRate, opt => opt.MapFrom(src => src.ScheduleItem.SellRate)).IncludeAllDerived()
                .ForMember(dest => dest.EffectivePercComp, opt => opt.MapFrom(src => src.Lot == null ? src.PercComp :
                    (src.Lot.DateConf != null || src.Lot.DateGuar != null) ? 1 :
                    ((src.PercComp.HasValue && src.PercComp.Value < 1) ? src.PercComp ?? 0 : src.Lot.PercentComplete ?? 0))).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.LotDescription, opt => opt.MapFrom(src => src.Lot.Description)).IncludeAllDerived()
                .ForMember(dest => dest.DateOpen, opt => opt.MapFrom(src => src.Lot.DateOpen)).IncludeAllDerived()
                .ForMember(dest => dest.DateGuar, opt => opt.MapFrom(src => src.Lot.DateGuar)).IncludeAllDerived()
                .ForMember(dest => dest.DateConf, opt => opt.MapFrom(src => src.Lot.DateConf)).IncludeAllDerived()
                .ForMember(dest => dest.DateRejected, opt => opt.MapFrom(src => src.Lot.DateRejected)).IncludeAllDerived();


            CreateMap<PhotoLot, PhotoLotReportDto>();

            CreateMap<Ncr, NcrRegisterReportDto>();
            CreateMap<Ncr, NcrDateReportDto>();
            CreateMap<Ncr, NcrReportDto>();
            CreateMap<NcrLot, NcrLotReportDto>();
            CreateMap<Photo, PhotoReportDto>();
            CreateMap<ProgressClaimDetail, ProgressClaimDetailReportDto>();
            CreateMap<ProgressClaimDetailReportDto, ProgressClaimDetailReportDto>();//For clone
            CreateMap<ProgressClaimSnapshot, ProgressClaimSnapshotReportDto>();
            CreateMap<ProgressClaimVersion, ProgressClaimVersionReportDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Description)).IncludeAllDerived()
                .ForMember(dest => dest.ProjectNumber, opt => opt.MapFrom(src => src.Project.ContractNumber)).IncludeAllDerived();

            CreateMap<PurchaseOrder, PurchaseOrderReportDto>();
            CreateMap<PurchaseOrder, PurchaseOrderWithDetailReportDto>();
            CreateMap<PurchaseOrder, PurchaseOrderReceiptReportDto>();

            CreateMap<Punchlist, PunchlistDto>()
                .ForMember(dest => dest.IsApproved, opt => opt.MapFrom(src => (src.ApprovedById ?? 0) > 0)).IncludeAllDerived();
            CreateMap<Punchlist, PunchlistReportDto>()
                .ForMember(dest => dest.RaisedByName, opt => opt.MapFrom(src => src.RaisedBy == null ? "" : src.RaisedBy.FirstName + " " + src.RaisedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.ApprovedByName, opt => opt.MapFrom(src => src.ApprovedBy == null ? "" : src.ApprovedBy.FirstName + " " + src.ApprovedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ((src.ApprovedById ?? 0) > 0) ? "Closed" : "Open")).IncludeAllDerived();
            CreateMap<PunchlistItem, PunchlistItemReportDto>()
                .ForMember(dest => dest.PersonResponsibleName, opt => opt.MapFrom(src => src.PersonResponsible == null ? "" : src.PersonResponsible.FirstName + " " + src.PersonResponsible.LastName)).IncludeAllDerived();
            CreateMap<PunchlistItem, PunchlistItemBaseDto>()
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => (src.DateCompleted != null))).IncludeAllDerived();
            CreateMap<PunchlistItem, PunchlistItemDto>();
            CreateMap<PunchlistItemDto, PunchlistItem>();
            CreateMap<PunchlistUser, PunchlistUserDto>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.UserId == null ? "" : src.User.FirstName + " " + src.User.LastName)).IncludeAllDerived();

            CreateMap<ScheduleItem, ScheduleFlatReportDto>();
            CreateMap<ScheduleFlatDto, ScheduleFlatDto>();//For clone
            CreateMap<ScheduleFlatReportDto, ScheduleFlatReportDto>();//For clone
            CreateMap<TestRequestTest, TestRequestTestReportDto>()
                .ForMember(dest => dest.LotId, opt => opt.MapFrom(src => src.TestRequest.LotId)).IncludeAllDerived()
                .ForMember(dest => dest.LotNumber, opt => opt.MapFrom(src => src.TestRequest.Lot.LotNumber)).IncludeAllDerived()
                .ForMember(dest => dest.TestRequestNo, opt => opt.MapFrom(src => src.TestRequest.TestRequestNo)).IncludeAllDerived()
                .ForMember(dest => dest.TestMethodNum, opt => opt.MapFrom(src => src.TestMethod.TestNum)).IncludeAllDerived()
                .ForMember(dest => dest.ScheduleNo, opt => opt.MapFrom(src => src.ScheduleItem.ScheduleNumber)).IncludeAllDerived()
                .ForMember(dest => dest.TestMethodDesc, opt => opt.MapFrom(src => src.TestMethod.TestDescription)).IncludeAllDerived()
                .ForMember(dest => dest.TestRequestNo, opt => opt.MapFrom(src => src.TestRequest.TestRequestNo)).IncludeAllDerived()
                .ForMember(dest => dest.TestReqMarkedComplete, opt => opt.MapFrom(src => src.TestRequest.DateTestCompleted != null)).IncludeAllDerived()
                .ForMember(dest => dest.TrDateSampled, opt => opt.MapFrom(src => src.TestRequest.DateRequest)).IncludeAllDerived()
                ;

            CreateMap<TestMethod, TestMethodReportDto>();
            CreateMap<TestMethod, TestMethodReportDto_concrete>();
            CreateMap<TestRequest, TestRequestDatesReportDto>();
            CreateMap<TestRequest, TestRequestReportDto>()
                .ForMember(dest => dest.ControlLineDescription, opt => opt.MapFrom(src => src.ControlLine.Description)).IncludeAllDerived();
            CreateMap<TestResult, TestResultReportDto>()
                .ForMember(dest => dest.TestReqId, opt => opt.MapFrom(src => src.TestRequestTest.TestRequest.TestRequestId)).IncludeAllDerived()
                .ForMember(dest => dest.SampleName, opt => opt.MapFrom(src => src.TestRequestTest.SampleId)).IncludeAllDerived()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.TestResultField.OrderId)).IncludeAllDerived()
                .ForMember(dest => dest.ResultFieldName, opt => opt.MapFrom(src => src.TestResultField.ResultFieldName)).IncludeAllDerived()
                .ForMember(dest => dest.ResultUnit, opt => opt.MapFrom(src => src.TestResultField.ResultUnit)).IncludeAllDerived()
                .ForMember(dest => dest.TestMethod, opt => opt.MapFrom(src => src.TestRequestTest.TestMethod.TestNum)).IncludeAllDerived()
                .ForMember(dest => dest.TestMethodDescription, opt => opt.MapFrom(src => src.TestRequestTest.TestMethod.TestDescription)).IncludeAllDerived();

            CreateMap<VariationEstimate, VariationEstimateReportDto>();
            CreateMap<PhotoVariation, PhotoVariationReportDto>()
                .ForMember(dest => dest.PhotoNo, opt => opt.MapFrom(src => src.Photo.PhotoNo)).IncludeAllDerived();
            CreateMap<VrnWaypoint, VrnWaypointReportDto>();
            CreateMap<Variation, VariationReportDto>()
                .ForMember(dest => dest.RaisedByName, opt => opt.MapFrom(src => src.RaisedBy == null ? "" : src.RaisedBy.FirstName + " " + src.RaisedBy.LastName)).IncludeAllDerived()
                .ForMember(dest => dest.CurrentStatusId, opt => opt.MapFrom(src => src.VrnWaypoints.OrderByDescending(x => x.WaypointDate).Select(x => x.VrnStatusId).FirstOrDefault())).IncludeAllDerived()
                .ForMember(dest => dest.CurrentStatusDate, opt => opt.MapFrom(src => src.VrnWaypoints.OrderByDescending(x => x.WaypointDate).Select(x => x.WaypointDate).FirstOrDefault())).IncludeAllDerived()
                .ForMember(dest => dest.HasBuildup, opt => opt.MapFrom(src => src.VariationEstimates.Count > 0)).IncludeAllDerived()
                ;

            //Reverse
            CreateMap<ApprovalListExtDto, Approval>()
                .Ignore(x => x.ApprovalTos).IncludeAllDerived()
                .Ignore(x => x.ApprovalCcs).IncludeAllDerived();
            CreateMap<ApprovalToDto, ApprovalTo>();
            CreateMap<ApprovalCcDto, ApprovalCc>();
            CreateMap<ApprovalWorkflowUpdaterDto, ApprovalWorkflow>();
            CreateMap<AtpLotListDto, AtpLot>();
            CreateMap<ContactDto, User>();
            CreateMap<ContractNoticeDto, ContractNotice>();
            CreateMap<ControlLinePointDto, ControlLinePoint>();
            CreateMap<CnApprovalDto, CnApproval>();
            CreateMap<CnControlledDocDto, CnControlledDoc>();
            CreateMap<CnIncidentDto, CnIncident>();
            CreateMap<CnItpDto, CnItp>();
            CreateMap<CnLotDto, CnLot>();
            CreateMap<CnNoticeDto, CnNotice>();
            CreateMap<CnPhotoDto, CnPhoto>();
            CreateMap<CnVariationDto, CnVariation>();
            CreateMap<ContractNotice_noBodyDto, ContractNotice>();
            CreateMap<CostCodeDto, CostCode>();
            CreateMap<CustomRegisterDto, CustomRegister>();
            CreateMap<CustomRegisterItemDto, CustomRegisterItem>();
            CreateMap<FileStoreDocDto, FileStoreDoc>();
            CreateMap<FsApprovalDto, FsApproval>();
            CreateMap<FsNoticeDto, FsNotice>();
            CreateMap<InstructionDto, Instruction>();
            CreateMap<ItpDto, Itp>();
            CreateMap<ItpDetailDto, ItpDetail>();
            CreateMap<ItpTestingDto, ItpTesting>();
            CreateMap<LotDto, Lot>();
            CreateMap<LotImportDto, Lot>();
            CreateMap<LotInstructionDto, LotInstruction>();
            CreateMap<LotItpDto, LotItp>();
            CreateMap<LotItpDetailDto, LotItpDetail>()
                .Ignore(x => x.Approval).IncludeAllDerived();
            CreateMap<LotItpTestDto, LotItpTest>();
            CreateMap<LotMapSectionEditDto, LotMapSection>();
            CreateMap<LotMapSectionForLayoutDto, LotMapSection>();
            CreateMap<LotMapSectionLotDto, LotMapSectionLot>();
            CreateMap<LotMapLayerEditDto, LotMapLayer>();
            CreateMap<LotMapLayerForLayoutDto, LotMapLayer>();
            CreateMap<LotShortListDto, Lot>();
            CreateMap<LotRelationDto, LotRelation>();
            CreateMap<LotTagDto, LotTag>();
            CreateMap<PhotoDto, Photo>();
            CreateMap<NcrDto, Ncr>()
                .Ignore(x => x.Approval).IncludeAllDerived();
            CreateMap<PurchaseOrderDto, PurchaseOrder>()
                .Ignore(x => x.Approval).IncludeAllDerived();
            CreateMap<PunchlistDto, Punchlist>();
            CreateMap<PurchaseOrderDetailDto, PurchaseOrderDetail>();
            CreateMap<PurchaseOrderDetailImportDto, PurchaseOrderDetail>();
            CreateMap<SurveyRequestDto, SurveyRequest>();
            CreateMap<TagCodeDto, TagCode>();
            CreateMap<TemplateDto, Template>();
            CreateMap<TestRequestDto, TestRequest>();
            CreateMap<TestRequestTestDto, TestRequestTest>();
            CreateMap<TestRequestPropertyDto, TestRequestProperty>();
            CreateMap<UnitDto, Unit>();

            CreateMap<VariationDto, Variation>();
            CreateMap<VariationLotDto, VariationLot>();
            if (!IsApi) CreateMap<WorkflowStepDto, WorkflowStep>();
            if (!IsApi) CreateMap<WorkflowActionDto, WorkflowAction>().Ignore(x => x.WorkflowActionPoints).Ignore(x => x.WorkflowActionRoles)
                .Ignore(x => x.WorkflowActionUsers);
            if (!IsApi) CreateMap<WorkflowActionPointDto, WorkflowActionPoint>();
            if (!IsApi) CreateMap<WorkflowActionRoleDto, WorkflowActionRole>();
            if (!IsApi) CreateMap<WorkflowActionUserDto, WorkflowActionUser>();
            CreateMap<WorkflowLogDto, WorkflowLog>();

            //Cloners
            CreateMap<Itp, ItpCloneDto>();
            CreateMap<ItpDetail, ItpDetailCloneDto>();
            CreateMap<ItpTesting, ItpTestingCloneDto>()
                .ForMember(dest => dest.TestNum, opt => opt.MapFrom(src => src.TestMethod.TestNum));
            CreateMap<User, UserCloneDto>();
            CreateMap<ContactDto, UserCloneDto>();
            CreateMap<ScheduleItem, ScheduleItemCloneDto>();
            CreateMap<ItpCloneDto, Itp>().Ignore(x => x.ItpId);
            CreateMap<ItpDetailCloneDto, ItpDetail>().Ignore(x => x.ItpDetailId);
            CreateMap<ItpTestingCloneDto, ItpTesting>().Ignore(x => x.ItpTestId);
            CreateMap<ScheduleItemCloneDto, ScheduleItem>().Ignore(x => x.ScheduleId);
            CreateMap<UserCloneDto, User>().Ignore(x => x.UserId);
        }

    }
}
