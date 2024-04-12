using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareDatabase.WindowUI
{
    public class CompareModel
    {
        public ConcurrentDictionary<string, CompareItem> items { get; set; } = new ConcurrentDictionary<string, CompareItem>();

        public CompareModel()
        {
        }

        public List<CompareItem> Data
        {
            get
            {
                return this.items.Values.ToList();
            }
        }

        public void AddTarget(Clients client)
        {
            var list = TextHelper.TableToText<Clients>(client);
            foreach(var item in list)
            {
                if (items.ContainsKey(item.Key))
                {
                    CompareItem? target = null;
                    if (items.TryGetValue(item.Key, out target))
                    {
                        target.Target = item.Value;
                        items.AddOrUpdate(item.Key, target, (x, y) => target);
                    }
                }
                else
                {
                    CompareItem target = new CompareItem();
                    target.Title = item.Key;
                    target.Target = item.Value;
                    items.AddOrUpdate(item.Key, target, (x, y) => target);
                }
            }
        }

        public void AddTarget(DataTable table)
        {
            var list = TextHelper.TableToText(table);
            foreach (var item in list)
            {
                if (items.ContainsKey(item.Key))
                {
                    CompareItem? target = null;
                    if (items.TryGetValue(item.Key, out target))
                    {
                        target.Target = item.Value;
                        items.AddOrUpdate(item.Key, target, (x, y) => target);
                    }
                }
                else
                {
                    CompareItem target = new CompareItem();
                    target.Title = item.Key;
                    target.Target = item.Value;
                    items.AddOrUpdate(item.Key, target, (x, y) => target);
                }
            }
        }

        public void AddTarget(Dictionary<string,string> list)
        {
            foreach (var item in list)
            {
                if (items.ContainsKey(item.Key))
                {
                    CompareItem? target = null;
                    if (items.TryGetValue(item.Key, out target))
                    {
                        target.Target = item.Value;
                        items.AddOrUpdate(item.Key, target, (x, y) => target);
                    }
                }
                else
                {
                    CompareItem target = new CompareItem();
                    target.Title = item.Key;
                    target.Target = item.Value;
                    items.AddOrUpdate(item.Key, target, (x, y) => target);
                }
            }
        }

        internal void AddTarget(string key, string value)
        {
            if (items.ContainsKey(key))
            {
                CompareItem? target = null;
                if (items.TryGetValue(key, out target))
                {
                    target.Target = value;
                    items.AddOrUpdate(key, target, (x, y) => target);
                }
            }
            else
            {
                CompareItem target = new CompareItem();
                target.Title = key;
                target.Target = value;
                items.AddOrUpdate(key, target, (x, y) => target);
            }
        }


        public void AddOrigin(Clients client)
        {
            var list = TextHelper.TableToText<Clients>(client);
            foreach (var item in list)
            {
                if (items.ContainsKey(item.Key))
                {
                    CompareItem? target = null;
                    if (items.TryGetValue(item.Key, out target))
                    {
                        target.Origin = item.Value;
                        items.AddOrUpdate(item.Key, target, (x, y) => target);
                    }
                }
                else
                {
                    CompareItem target = new CompareItem();
                    target.Title = item.Key;
                    target.Origin = item.Value;
                    items.AddOrUpdate(item.Key, target, (x, y) => target);
                }
            }
        }

        public void AddOrigin(DataTable table)
        {
            var list = TextHelper.TableToText(table);
            foreach (var item in list)
            {
                if (items.ContainsKey(item.Key))
                {
                    CompareItem? target = null;
                    if (items.TryGetValue(item.Key, out target))
                    {
                        target.Origin = item.Value;
                        items.AddOrUpdate(item.Key, target, (x, y) => target);
                    }
                }
                else
                {
                    CompareItem target = new CompareItem();
                    target.Title = item.Key;
                    target.Origin = item.Value;
                    items.AddOrUpdate(item.Key, target, (x, y) => target);
                }
            }
        }

        public void AddOrigin(Dictionary<string,string> list)
        {
            foreach (var item in list)
            {
                if (items.ContainsKey(item.Key))
                {
                    CompareItem? target = null;
                    if (items.TryGetValue(item.Key, out target))
                    {
                        target.Origin = item.Value;
                        items.AddOrUpdate(item.Key, target, (x, y) => target);
                    }
                }
                else
                {
                    CompareItem target = new CompareItem();
                    target.Title = item.Key;
                    target.Origin = item.Value;
                    items.AddOrUpdate(item.Key, target, (x, y) => target);
                }
            }
        }

        internal void AddOrigin(string key, string value)
        {
            if (items.ContainsKey(key))
            {
                CompareItem? target = null;
                if (items.TryGetValue(key, out target))
                {
                    target.Origin = value;
                    items.AddOrUpdate(key, target, (x, y) => target);
                }
            }
            else
            {
                CompareItem target = new CompareItem();
                target.Title = key;
                target.Origin = value;
                items.AddOrUpdate(key, target, (x, y) => target);
            }
        }
    }

    public class CompareItem
    {
        public string Title { get; set; } = string.Empty;

        public string Origin { get; set; } = string.Empty;

        public string Target { get; set; } = string.Empty;

        public bool IsCompare
        {
            get
            {
                return this.Origin.Trim().Equals(this.Target.Trim(), StringComparison.OrdinalIgnoreCase);
            }
        }

        public CompareItem()
        {
        }
    }
}
