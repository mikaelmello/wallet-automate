namespace WalletCore.Models {
    public enum RecordState {
        RECONCILED,
        CLEARED,
        UNCLEARED,
        VOID,
        WAIT_FOR_ASSIGN,
    }
}