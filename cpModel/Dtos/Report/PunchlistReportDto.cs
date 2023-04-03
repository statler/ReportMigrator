using cpShared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpModel.Dtos.Report
{
    public class PunchlistReportDto : PunchlistDto
    {
        public string Status { get; set; }
        public string RaisedByName { get; set; }
        public string ApprovedByName { get; set; }

        public List<PunchlistItemReportDto> LstPunchlistItems { get; set; }
        public List<UserAlias> LstUserAliases { get; set; }

        HashSet<int> GetUserIdList()
        {
            HashSet<int> hsIds = new HashSet<int>();
            foreach (PunchlistItemReportDto _item in LstPunchlistItems)
            {
                if (_item.CheckById != null) hsIds.Add(_item.CheckById.Value);
                if (_item.VerifyById != null) hsIds.Add(_item.VerifyById.Value);
                if (_item.ApprovedById != null) hsIds.Add(_item.ApprovedById.Value);
            }
            return hsIds;
        }

        public void CompileAliases(Func<HashSet<int>, Dictionary<int, string>> fnGetUserDictinary)
        {
            var hsIds = GetUserIdList();
            var dctUsers = fnGetUserDictinary(hsIds);
            Dictionary<string, string> dctAliases = new Dictionary<string, string>();
            LstUserAliases = new List<UserAlias>();
            foreach (var _u in dctUsers)
            {
                if (string.IsNullOrEmpty(_u.Value)) continue;
                var _spl = _u.Value.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (_spl.Length < 2) continue;
                var _init = _spl[0].Left(1) + _spl[1].Left(1);

                int i = 3;
                while (dctAliases.ContainsKey(_init) && dctAliases[_init] != _u.Value && i < 6)
                {
                    _init = _spl[0].Left(i / 2) + _spl[1].Left((i / 2) + (i % 2));
                }
                if (!dctAliases.ContainsKey(_init)) dctAliases[_init] = _u.Value;
                LstUserAliases.Add(new UserAlias(_u.Key, _init, _u.Value));
            }

            var dctUserToAlias = LstUserAliases.ToDictionary(x => x.UserId, x => x.Alias);

            foreach (PunchlistItemReportDto _item in LstPunchlistItems)
            {
                if (_item.CheckById != null && dctUserToAlias.ContainsKey(_item.CheckById.Value)) _item.CheckedByInit = dctUserToAlias[_item.CheckById.Value];
                if (_item.VerifyById != null && dctUserToAlias.ContainsKey(_item.VerifyById.Value)) _item.CheckedByInit = dctUserToAlias[_item.VerifyById.Value];
                if (_item.ApprovedById != null && dctUserToAlias.ContainsKey(_item.ApprovedById.Value)) _item.CheckedByInit = dctUserToAlias[_item.ApprovedById.Value];
            }
        }

    }
    public class UserAlias
    {
        public int UserId { get; set; }
        public string Alias { get; set; }
        public string FullName { get; set; }
        public UserAlias(int userId, string alias, string fullName)
        {
            UserId = userId;
            Alias = alias;
            FullName = fullName;
        }
        public UserAlias()
        {

        }
    }
}
