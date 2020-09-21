using Xamarin.Forms.Internals;

namespace fmmApp.Controls
{
    /// <summary>
    /// This class extends the behavior of the SfListView control to filter the items in Songs PlayList page based on text.
    /// </summary>
    [Preserve(AllMembers = true)]

    public class CategoryList : SearchableListView
    {
        #region Method

        /// <summary>
        /// Filtering the list view items based on the search text.
        /// </summary>
        /// <param name="obj">The list view item</param>
        /// <returns>Returns the filtered item</returns>
        public override bool Filter(object obj)
        {
            if (base.Filter(obj))
            {
                var taskInfo = obj as Models.Category;

                if (taskInfo == null || string.IsNullOrEmpty(taskInfo.Description))
                {
                    return false;
                }

                return taskInfo.Description.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant());
            }
            return false;
        }
        #endregion
    }
}
