﻿using OohelpWebApps.Presentations.Domain;

namespace OohelpWebApps.Presentations.Api.Contracts.Requests;

public class CreatePresentationRequest : BaseRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool ShowOwner { get; set; }
    public List<Board> Boards { get; set; }
}
