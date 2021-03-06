import { QuestionSetDetail } from "models/questionSet/QuestionSetDetail";
import { DocumentFormLabel } from "settings/document/documentForm";
import { DocumentTypeLabel } from "settings/document/documentType";

export interface DocumentCreate {
  name: string;
  gradeId?: string;
  subjectId?: string;
  description: string;
  documentType: number;
}
export interface DocumentExam {
  name: string;
  id: string;
  questionSets: QuestionSetDetail[];
  form?: DocumentFormLabel;
  times: number;
  documentType: DocumentTypeLabel;
}
