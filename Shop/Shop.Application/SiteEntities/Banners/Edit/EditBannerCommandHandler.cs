﻿using Common.Applications;
using Common.Applications._Utilities;
using Common.Applications.FileUtil.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Application.SiteEntities.Banners.Edit;

public class EditBannerCommandHandler:IBaseCommandHandler<EditBannerCommand>
{
    private readonly IBannerRepository _repository;
    private readonly IFileService _fileService;

    public EditBannerCommandHandler(IBannerRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetTracking(request.Id);
        if (banner == null)
            return OperationResult.NotFound();

        var imageName = banner.ImageName;
        if(request.ImageFile != null)
             imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);


        banner.Edit(request.Link, imageName, request.Position);
        await _repository.Save();
        return OperationResult.Success();

    }
}