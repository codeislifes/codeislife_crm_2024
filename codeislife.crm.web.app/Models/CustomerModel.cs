﻿namespace codeislife.crm.web.app.Models;
public class CustomerModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Code { get; set; }
    public int ContactCount { get; set; }
    public int LeadCount { get; set; }
}