using System;
using System.Linq.Expressions;
using N2.Web.UI;

namespace N2.Web.Mvc.Html
{
	public static class EditableDisplayableExtensions
	{
		public static EditableDisplayable EditableDisplay<TItem>(this IItemContainer<TItem> container, string detailName)
			where TItem : ContentItem
		{
			return new EditableDisplayable(Context.Current.Resolve<ITemplateRenderer>(), container, detailName);
		}

		public static EditableDisplayable EditableDisplay<TItem>(this IItemContainer<TItem> container, Expression<Func<TItem, object>> expression)
			where TItem : ContentItem
		{
			var member = (MemberExpression)expression.Body;

			return container.EditableDisplay(member.Member.Name);
		}

		public static EditableDisplayable EditableDisplay<TItem>(this IItemContainer container, TItem item, string detailName)
			where TItem : ContentItem
		{
			return new EditableDisplayable(Context.Current.Resolve<ITemplateRenderer>(), container, detailName, item);
		}

		public static EditableDisplayable EditableDisplay<TItem>(this IItemContainer container, TItem item, Expression<Func<TItem, object>> expression)
			where TItem : ContentItem
		{
			var member = (MemberExpression)expression.Body;

			return container.EditableDisplay(item, member.Member.Name);
		}

	}

	public class EditableDisplayable : Displayable
	{
		public EditableDisplayable(ITemplateRenderer templateRenderer, IItemContainer container, string detailName)
			: base(templateRenderer, container, detailName)
		{
		}

		public EditableDisplayable(ITemplateRenderer templateRenderer, IItemContainer container, string detailName, ContentItem item)
			: base(templateRenderer, container, detailName, item)
		{
		}
	}
}