import TemplatePreview from "app/components/_share/TemplatePreview";
import { useHistoryQuestions } from "hooks/Question/historyQuestionExam";
import { Question } from "models/question/Question";
import React, { createRef, useEffect, useState } from "react";
import { getClassStatusQuestion } from "utils/questionFunction";
import clsx from "clsx";
import SnipperBall from "app/components/_share/StaticLayout/SnipperBall";
interface Props {
  question: Question;
}
const QuestionMultipleChoice: React.FC<Props> = ({ question }) => {
  const {
    content = [],
    introduction = [],
    correctAnswer,
    solve = [],
  } = question;
  const { setQuestionHistoryIndex, userAnswerIndex, canShowSolve } =
    useHistoryQuestions();
  const [optionsRef] = useState(createRef<HTMLDivElement>());
  const questionHistory = userAnswerIndex(question.id) || {};
  const setAnswer = setQuestionHistoryIndex(question.id);
  const [boxRefs] = useState<any[]>(
    Array(content ? content.length : 0)
      .fill(null)
      .map(() => createRef())
  );

  const [scaleSize, setScaleSize] = useState<any>({});
  useEffect(() => {
    setScaleSize({ width: "auto", height: "auto" });
    setTimeout(() => {
      let lengthMax = 0;
      let heightMax = 0;
      boxRefs.forEach((el) => {
        if (el.current) {
          lengthMax = Math.max(lengthMax, el.current?.clientWidth);
          heightMax = Math.max(heightMax, el.current?.clientHeight);
        }
      });

      const newScale = {} as any;
      newScale.width = lengthMax + 25;
      newScale.height = heightMax + 5;

      var optionBoxWidth = optionsRef.current?.clientWidth || 0;

      if (lengthMax < optionBoxWidth / 4 - 37) {
        newScale.width = optionBoxWidth / 2 - 21;
      } else if (lengthMax < optionBoxWidth / 2 - 37) {
        newScale.width = optionBoxWidth / 2 - 21;
      } else {
        newScale.width = optionBoxWidth - 25;
        newScale.height = "auto";
      }

      setScaleSize(newScale);
    });

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, content);
  const getScale = () => ({
    width: scaleSize?.width || "auto",
    height: scaleSize?.height || "auto",
    minWidth: 100,
  });
  return (
    <div className="question-multiple-choice" id={`qid-${question.id}`}>
      <div className="question-introduction">
        {introduction &&
          introduction.map((element, i) => (
            <TemplatePreview key={i} {...element} />
          ))}
      </div>
      <div
        id={`option-${question.id}`}
        className="question-options"
        ref={optionsRef}
      >
        {content &&
          content.map((option, i) => (
            <div
              className="option-item d-inline-flex"
              style={getScale()}
              ref={boxRefs[i]}
              key={i}
            >
              <div
                className={`name-option ${
                  option.name === questionHistory.answer
                    ? `active ${getClassStatusQuestion(questionHistory)}`
                    : ""
                }  `}
                onClick={() => setAnswer(option.name)}
              >
                {option.name}
              </div>
              <div className="content-option">
                {option.content.map((element, i_option) => (
                  <TemplatePreview key={i_option} {...element} />
                ))}
              </div>
            </div>
          ))}
      </div>
      {canShowSolve && (
        <div className="solve-block">
          <div className={clsx("solve-content")}>
            {correctAnswer ? (
              <>
                <div className="correct-answer">
                  Đáp án đúng : {correctAnswer}
                </div>
                <div className="solve">
                  {solve &&
                    solve.map((element, i) => (
                      <TemplatePreview key={i} {...element} />
                    ))}
                </div>
              </>
            ) : (
              <div className="loading d-flex justify-content-center p-2 pb-3">
                <SnipperBall />
              </div>
            )}
          </div>
        </div>
      )}
    </div>
  );
};

export default QuestionMultipleChoice;
