using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace DFe.Utils
{
    public enum TipoCertificado
    {
        [Description("Certificado A1")]
        A1Repositorio = 0,

        [Description("Certificado A1 em arquivo")]
        A1Arquivo = 1,

        [Description("Certificado A3")]
        A3 = 2,

        [Description("Certificado A1 em byte array")]
        A1ByteArray = 3
    }

    public class ConfiguracaoCertificado
    {
        private string _serial;
        private string _arquivo;
        private string _senha;
        private TipoCertificado _tipoCertificado;
        private string _cacheId;
        private byte[] _arrayBytesArquivo;
        private X509KeyStorageFlags _keyStorageFlags;

        public ConfiguracaoCertificado()
        {
            KeyStorageFlags = X509KeyStorageFlags.MachineKeySet;
            SignatureMethodSignedXml = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
            DigestMethodReference = "http://www.w3.org/2000/09/xmldsig#sha1";
        }

        /// <summary>
        /// Tipo de certificado a ser usado
        /// </summary>
        public TipoCertificado TipoCertificado
        {
            get { return _tipoCertificado; }
            set
            {
                Serial = null;
                Arquivo = null;
                Senha = null;
                ArrayBytesArquivo = null;
                _tipoCertificado = value;
            }
        }

        /// <summary>
        ///     Nº de série do certificado digital
        /// </summary>
        public string Serial
        {
            get { return _serial; }
            set
            {
                if (!string.IsNullOrEmpty(value) && TipoCertificado == TipoCertificado.A1Arquivo)
                    throw new Exception(string.Format("Para {0} o {1} não deve ser informado!", TipoCertificado.Descricao(), this.ObterPropriedadeInfo(c => c.Serial).Name));

                if (value == _serial) return;
                _serial = value;
                if (!string.IsNullOrEmpty(value))
                    Arquivo = null;
            }
        }

        /// <summary>
        /// Array de bytes do certificado
        /// </summary>
        public byte[] ArrayBytesArquivo
        {
            get { return _arrayBytesArquivo; }
            set
            {
                if (value == _arrayBytesArquivo) return;
                _arrayBytesArquivo = value;
            }
        }


        /// <summary>
        ///     Arquivo do certificado digital
        /// </summary>
        public string Arquivo
        {
            get { return _arquivo; }
            set
            {
                if (!string.IsNullOrEmpty(value) && TipoCertificado != TipoCertificado.A1Arquivo)
                    throw new Exception(string.Format("Para {0} o {1} não deve ser informado!", TipoCertificado.Descricao(), this.ObterPropriedadeInfo(c => c.Arquivo).Name));
                if (value == _arquivo) return;
                _arquivo = value;
                if (!string.IsNullOrEmpty(value))
                    Serial = null;
            }
        }

        /// <summary>
        ///     Senha do certificado digital
        /// <para>Informe a senha se desejar que o usuário não precise digitá-la toda vez que for iniciada uma nova instância da aplicação.
        /// Não informe a senha para certificado A1, exceto se configurar para usar o arquivo .pfx usando o atributo <see cref="Arquivo"/></para>
        /// </summary>
        public string Senha
        {
            get { return _senha; }
            set
            {
                if (!string.IsNullOrEmpty(value) && TipoCertificado == TipoCertificado.A1Repositorio)
                    throw new Exception(string.Format("Para {0} o {1} não deve ser informada!", TipoCertificado.Descricao(), this.ObterPropriedadeInfo(c => c.Senha).Name));
                if (value == _senha) return;
                _senha = value;
            }
        }

        /// <summary>
        /// Id do certificado no cache do Zeus
        /// </summary>
        public string CacheId
        {
            get { return _cacheId; }
            set
            {
                if (value == _cacheId) return;
                _cacheId = value;
            }
        }

        /// <summary>
        ///     Manter/Não manter os dados do certificado em Cache, enquanto a aplicação que consome a biblioteca estiver aberta
        /// <para>Manter os dados do certificado em cache, aumentará o desempenho no consumo dos serviços, especialmente para certificados A3</para>
        /// </summary>
        public bool ManterDadosEmCache { get; set; }



        /// <summary>
        ///     Algoritmo de Assinatura (Padrao: http://www.w3.org/2000/09/xmldsig#rsa-sha1)
        /// </summary>
        public string SignatureMethodSignedXml { get; set; }


        /// <summary>
        ///     URI para DigestMethod na Classe Reference para auxiliar para a assinatura (Padrao: http://www.w3.org/2000/09/xmldsig#sha1)
        /// </summary>
        public string DigestMethodReference { get; set; }

        /// <summary>
        ///     
        /// </summary>
        public X509KeyStorageFlags KeyStorageFlags
        {
            get { return _keyStorageFlags; }
            set
            {
                if (value == _keyStorageFlags) return;
                _keyStorageFlags = value;
            }
        }
    }
}