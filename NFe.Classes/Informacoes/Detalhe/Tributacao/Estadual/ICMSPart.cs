using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using System.Xml.Serialization;

namespace NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual
{
    public class ICMSPart : ICMSBasico
    {
        private decimal _vBc;
        private decimal? _pRedBc;
        private decimal _pIcms;
        private decimal _vIcms;
        private decimal? _pMvast;
        private decimal? _pRedBcst;
        private decimal _vBcst;
        private decimal _pIcmsst;
        private decimal _vIcmsst;
        private decimal? _vBCFCPST;
        private decimal? _pFCPST;
        private decimal? _vFCPST;
        private decimal _pBcOp;

        /// <summary>
        ///     N11 - Origem da Mercadoria
        /// </summary>
        [XmlElement(Order = 1)]
        public OrigemMercadoria orig { get; set; }

        /// <summary>
        ///     N12- Situação Tributária
        /// </summary>
        [XmlElement(Order = 2)]
        public Csticms CST { get; set; }

        /// <summary>
        ///     N13 - Modalidade de determinação da BC do ICMS
        /// </summary>
        [XmlElement(Order = 3)]
        public DeterminacaoBaseIcms modBC { get; set; }

        /// <summary>
        ///     N15 - Valor da BC do ICMS
        /// </summary>
        [XmlElement(Order = 4)]
        public decimal vBC
        {
            get { return _vBc; }
            set { _vBc = value.Arredondar(2); }
        }

        /// <summary>
        ///     N14 - Percentual de redução da BC
        /// </summary>
        [XmlElement(Order = 5)]
        public decimal? pRedBC
        {
            get { return _pRedBc.Arredondar(4); }
            set { _pRedBc = value.Arredondar(4); }
        }

        /// <summary>
        ///     N16 - Alíquota do imposto
        /// </summary>
        [XmlElement(Order = 6)]
        public decimal pICMS
        {
            get { return _pIcms; }
            set { _pIcms = value.Arredondar(4); }
        }

        /// <summary>
        ///     N17 - Valor do ICMS
        /// </summary>
        [XmlElement(Order = 7)]
        public decimal vICMS
        {
            get { return _vIcms; }
            set { _vIcms = value.Arredondar(2); }
        }

        /// <summary>
        ///     N18 - Modalidade de determinação da BC do ICMS ST
        /// </summary>
        [XmlElement(Order = 8)]
        public DeterminacaoBaseIcmsSt modBCST { get; set; }

        /// <summary>
        ///     N19 - Percentual da margem de valor Adicionado do ICMS ST
        /// </summary>
        [XmlElement(Order = 9)]
        public decimal? pMVAST
        {
            get { return _pMvast.Arredondar(4); }
            set { _pMvast = value.Arredondar(4); }
        }

        /// <summary>
        ///     N20 - Percentual da Redução de BC do ICMS ST
        /// </summary>
        [XmlElement(Order = 10)]
        public decimal? pRedBCST
        {
            get { return _pRedBcst.Arredondar(4); }
            set { _pRedBcst = value.Arredondar(4); }
        }

        /// <summary>
        ///     N21 - Valor da BC do ICMS ST
        /// </summary>
        [XmlElement(Order = 11)]
        public decimal vBCST
        {
            get { return _vBcst; }
            set { _vBcst = value.Arredondar(2); }
        }

        /// <summary>
        ///     N22 - Alíquota do imposto do ICMS ST
        /// </summary>
        [XmlElement(Order = 12)]
        public decimal pICMSST
        {
            get { return _pIcmsst; }
            set { _pIcmsst = value.Arredondar(4); }
        }

        /// <summary>
        ///     N23 - Valor do ICMS ST
        /// </summary>
        [XmlElement(Order = 13)]
        public decimal vICMSST
        {
            get { return _vIcmsst; }
            set { _vIcmsst = value.Arredondar(2); }
        }

        /// <summary>
        ///     N23.a - Valor da Base de Cálculo do FCP ST
        /// </summary>
        [XmlElement(Order = 14)]
        public decimal? vBCFCPST
        {
            get { return _vBCFCPST; }
            set { _vBCFCPST = value.Arredondar(2); }
        }

        /// <summary>
        ///     N23.b - Percentual do FCP ST
        /// </summary>
        [XmlElement(Order = 15)]
        public decimal? pFCPST
        {
            get { return _pFCPST; }
            set { _pFCPST = value.Arredondar(4); }
        }

        /// <summary>
        ///     N23.c - Valor do FCP ST 
        /// </summary>
        [XmlElement(Order = 16)]
        public decimal? vFCPST
        {
            get { return _vFCPST; }
            set { _vFCPST = value.Arredondar(2); }
        }

        /// <summary>
        ///     N25 - Percentual da BC operação própria
        /// </summary>
        [XmlElement(Order = 17)]
        public decimal pBCOp
        {
            get { return _pBcOp; }
            set { _pBcOp = value.Arredondar(4); }
        }

        /// <summary>
        ///     N24 - UF para qual é devido o ICMS ST
        /// </summary>
        [XmlElement(Order = 18)]
        public string UFST { get; set; }

        public bool ShouldSerializepRedBC()
        {
            return pRedBC.HasValue;
        }

        public bool ShouldSerializepMVAST()
        {
            return pMVAST.HasValue;
        }

        public bool ShouldSerializepRedBCST()
        {
            return pRedBCST.HasValue;
        }

        public bool ShouldSerializevBCFCPST()
        {
            return vBCFCPST.HasValue;
        }

        public bool ShouldSerializepFCPST()
        {
            return pFCPST.HasValue;
        }

        public bool ShouldSerializevFCPST()
        {
            return vFCPST.HasValue;
        }

    }
}