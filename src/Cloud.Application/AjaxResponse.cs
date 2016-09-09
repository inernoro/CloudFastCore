namespace Cloud.ApiManager.Manager
{
    internal class AjaxResponse<T>
    {
        public object Result { get; set; }
        public bool Success { get; set; }
    }
}