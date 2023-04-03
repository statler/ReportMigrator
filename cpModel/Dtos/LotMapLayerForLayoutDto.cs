using cpModel.Enums;
using cpModel.Interfaces;
using IntervalTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpModel.Dtos
{
    public class LotMapLayerForLayoutDto : LotMapLayerDto
    {
        public double TopCoord { get; set; }
        public double BaseCoord { get; set; }
        public double LayerHeightInclPadding => TopCoord - BaseCoord;
        public string CustomRegisterName { get; set; }
        public LotMapSectionForLayoutDto SectionForLayout { get; set; }
        public List<LotListForMapDto> LayerLots { get; set; }
        public FilterOperationEnum? FilterOperationType { get => (FilterOperationEnum)(IsAndOr ?? (int)FilterOperationEnum.And); set => IsAndOr = (int?)value; }

        Dictionary<int, List<LotListForMapDto>> _dctLotOverlap { get; set; }
        public Dictionary<int, List<LotListForMapDto>> GetDctLotOverlap(double Scale)
        {
            if (_dctLotOverlap == null) CalcLotLayers(Scale);
            return _dctLotOverlap;
        }

        public void CalcLotLayers(double Scale)
        {
            int _currentLayer;
            _dctLotOverlap = new Dictionary<int, List<LotListForMapDto>>();
            var _effTolerance = (OverlapTolerance ?? 0.1);
            if (Scale != 0) _effTolerance = _effTolerance / Scale;
            _currentLayer = 0;
            List<LotListForMapDto> _unlayeredLots = LayerLots;

            while (_unlayeredLots.Count > 0)
            {
                var tree = new IntervalTree<double, string>();
                var _unlayeredLotsOrdered = _unlayeredLots.OrderByDescending(x => x.DateOpen).ToList();
                _unlayeredLots = new List<LotListForMapDto>();
                var _Layered = new List<LotListForMapDto>();
                foreach (var _lot in _unlayeredLotsOrdered)
                {
                    var _leftEdge_tol = _lot.LeftCoord + _effTolerance;
                    var _rightEdge_tol = _lot.RightCoord - _effTolerance;
                    if (_rightEdge_tol < _leftEdge_tol) _rightEdge_tol = _leftEdge_tol;
                    var match = tree.Query(_leftEdge_tol, _rightEdge_tol);
                    if (match.Count() > 0) _unlayeredLots.Add(_lot);
                    else
                    {
                        tree.Add(_lot.LeftCoord, _lot.RightCoord, _lot.LotNumber);
                        _Layered.Add(_lot);
                    }
                }
                
                _dctLotOverlap[_currentLayer] = _Layered;
                _currentLayer++;
            }
        }
    }

}
