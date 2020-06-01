namespace Take.BatePapo.Dominio.Enumeracoes
{
    /// <summary>
    /// Define o tipo da mensagem enviada
    /// 1 = mensagem aberta encaminhada para todos participantes.
    /// 2 = mensagem privada encaminhada para um determinado participante.
    /// 3 = mensagem aberta encaminhada para um determinado participante.
    /// 4 = mensagem de comando: entrar/sair do chat
    /// </summary>
    /// 
    public enum ETipoDaMensagem
    {
        Todos = 1,
        Privada = 2,
        Aberta = 3,
        Comando = 4
    }
}
