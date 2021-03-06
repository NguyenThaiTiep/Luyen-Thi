import QuestionPreview from "app/components/question/QuestionPreview";
import { QuestionSetDetail } from "models/questionSet/QuestionSetDetail";
import React from "react";
import "./style.scss";
interface Props {
  data: QuestionSetDetail;
}
const QuestionSetPreview: React.FC<Props> = ({ data }) => {
  return (
    <div className="question-set-preview">
      {data.show && <div className="question-set-title">{data.name}</div>}
      <div className="questions-preview">
        {data.questions.map((question, i) => (
          <QuestionPreview key={i} data={question} questionSetId={data.id} />
        ))}
      </div>
    </div>
  );
};

export default QuestionSetPreview;
