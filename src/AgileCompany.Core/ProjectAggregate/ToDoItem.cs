﻿using Ardalis.GuardClauses;
using AgileCompany.Core.ProjectAggregate.Events;
using AgileCompany.SharedKernel;

namespace AgileCompany.Core.ProjectAggregate;

public class ToDoItem : EntityBase
{
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public int? ContributorId { get; private set; }
  public bool IsDone { get; private set; }

  public void MarkComplete()
  {
    if (!IsDone)
    {
      IsDone = true;

      RegisterDomainEvent(new ToDoItemCompletedEvent(this));
    }
  }

  public void AddContributor(int contributorId)
  {
    Guard.Against.Null(contributorId, nameof(contributorId));
    ContributorId = contributorId;

    var contributorAddedToItem = new ContributorAddedToItemEvent(this, contributorId);
    base.RegisterDomainEvent(contributorAddedToItem);
  }

  public void RemoveContributor()
  {
    ContributorId = null;
  }

  public override string ToString()
  {
    string status = IsDone ? "Done!" : "Not done.";
    return $"{Id}: Status: {status} - {Title} - {Description}";
  }
}
