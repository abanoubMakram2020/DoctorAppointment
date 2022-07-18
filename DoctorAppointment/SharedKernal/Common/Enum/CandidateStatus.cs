namespace SharedKernal.Common.Enum
{
    public enum CandidateStatus : int
    {
        ///<summary>
        ///تم إرسال الطلب
        /// Request has been sent
        /// </summary>
        [EnumMessage(messageAr: " إرسال ", messageEn: "Send")]
        Sent = 529401,

        ///<summary>
        ///إرسال الرفض
        /// Rejection Sent
        /// </summary>
        [EnumMessage(messageAr: " رفض ", messageEn: "Reject")]
        ConfidentialBureauRejectSent = 529402,

        ///<summary>
        ///تم الرفض
        /// Rejected
        /// </summary>
        [EnumMessage(messageAr: " رفض ", messageEn: "Reject")]
        ConfidentialBureauReject = 529403,

        ///<summary>
        ///إرسال القبول
        /// Approval sent
        /// </summary>
        [EnumMessage(messageAr: " قبول ", messageEn: "Approve")]
        ConfidentialBureauApproveSent = 529404,

        ///<summary>
        ///تم القبول
        /// Approved
        /// </summary>
        [EnumMessage(messageAr: " قبول ", messageEn: "Approve")]
        ConfidentialBureauApprove = 529405,

        ///<summary>
        ///إرسال الأعادة
        /// Return Sent
        /// </summary>
        [EnumMessage(messageAr: " الأعادة ", messageEn: "Return")]
        ConfidentialBureauReturnSent = 529406,

        ///<summary>
        ///تم الأعادة
        /// Returned
        /// </summary>
        [EnumMessage(messageAr: " معاد ", messageEn: "Return")]
        ConfidentialBureauReturn = 529407,

        ///<summary>
        /// إرجاع المرشح لمقدم الطلب 
        /// Return candidate to requester
        /// </summary>
        [EnumMessage(messageAr: " إرجاع المرشح لمقدم الطلب ", messageEn: "Return candidate to requester")]
        ReturnCandidate_CE = 529408,

        ///<summary>
        ///قبول المُرشح من موظف المكتب السري
        /// Approve candidate from confidential bureau employee
        /// </summary>
        [EnumMessage(messageAr: " قبول المُرشح ", messageEn: "Approve candidate")]
        ApproveCandidate_CE = 529409,

        ///<summary>
        ///رفض المُرشح من موظف المكتب السري
        /// Reject candidate from confidential bureau employee
        /// </summary>
        [EnumMessage(messageAr: " رفض المُرشح ", messageEn: "Reject candidate")]
        RejectCandidate_CE = 529410,

        ///<summary>
        ///إرجاع المُرشح إلى موظف المكتب السري
        /// Return candidate to confidential bureau employee
        /// </summary>
        [EnumMessage(messageAr: " إرجاع المُرشح ", messageEn: "Return candidate")]
        ReturnCandidate_CH = 529411,

        ///<summary>
        ///إرسال المُرشح إلى الأدارة القانونية
        /// Send candidate to legal administration
        /// </summary>
        [EnumMessage(messageAr: " إرسال المُرشح ", messageEn: "Send candidate")]
        SendCandidateToLA_CH = 529412,

        ///<summary>
        ///إرسال المُرشح إلى أدارة الموارد البشرية
        /// Send candidate to human resourcres administration
        /// </summary>
        [EnumMessage(messageAr: " إرسال المُرشح ", messageEn: "Send candidate")]
        SendCandidateToHR_CH = 529413,

        ///<summary>
        ///قبول المُرشح من مدير المكتب السري
        /// Approve candidate from confidential bureau manager
        /// </summary>
        [EnumMessage(messageAr: " قبول المُرشح ", messageEn: "Approve candidate")]
        ApproveCandidate_CH = 529414,

        ///<summary>
        ///رفض المُرشح من مدير المكتب السري
        /// Reject candidate from confidential bureau manager
        /// </summary>
        [EnumMessage(messageAr: " رفض المُرشح ", messageEn: "Reject candidate")]
        RejectCandidate_CH = 529415,

        ///<summary>
        ///إرجاع المرشح من مدير المكتب السري لمقدم الطلب
        /// Return candidate from confidential bureau manager to requester
        /// </summary>
        [EnumMessage(messageAr: " إرجاع المرشح ", messageEn: "Return candidate")]
        ReturnCandidateToRequester_CH = 529416,

        ///<summary>
        ///رفض المرشح من مدير الأدارة القانونية
        /// Reject candidate from legal administration manager
        /// </summary>
        [EnumMessage(messageAr: " رفض المرشح ", messageEn: "Reject candidate")]
        RejectCandidate_LAM = 529417,

        ///<summary>
        /// إرجاع المُرشح من مدير الأدارة القانونية إالى مدير المكتب السري
        /// Return candidate from legal administration manager to confidential bureau manager
        /// </summary>
        [EnumMessage(messageAr: " إرجاع المُرشح ", messageEn: "Return candidate")]
        ReturnCandidate_LAM = 529418,

        ///<summary>
        ///رفض المُرشح من مدير أدارة الموارد البشرية
        /// Reject candidate from human resources manager
        /// </summary>
        [EnumMessage(messageAr: " رفض المُرشح ", messageEn: "Reject candidate")]
        RejectCandidate_HRM = 529419,

        ///<summary>
        ///إرجاع المُرشح من مدير أدارة الموارد البشريةإلى مدير المكتب السري
        /// Return candidate from  human resources manager to confidential bureau manager
        /// </summary>
        [EnumMessage(messageAr: " إرجاع المُرشح ", messageEn: "Return candidate")]
        ReturnCandidate_HRM = 529420,

        ///<summary>
        ///إسناد لموظف أدارة الموارد البشرية و إعداد القرار
        /// Assignment to human resources administration employee and make a decision
        /// </summary>
        [EnumMessage(messageAr: " إسناد لموظف و إعداد القرار ", messageEn: "Assignment to employee")]
        AssignmentToEmployee_HRM = 529421,

        ///<summary>
        ///إسناد لموظف أدارة الموارد القانونية و إعداد القرار
        /// Assignment to human legal administration employee and make a decision
        /// </summary>
        [EnumMessage(messageAr: " إسناد لموظف و إعداد القرار ", messageEn: "Assignment to employee")]
        AssignmentToEmployee_LAM = 529422,
    }

}
