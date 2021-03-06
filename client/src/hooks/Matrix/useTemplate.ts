import { TemplateQuestion } from "models/matrix/TemplateQuestion";
import { useState, useEffect } from "react";

export const useQuestionTemplate = (unitId?: string) => {
  const [templates, setTemplate] = useState<TemplateQuestion[]>([]);
  const [currentTemplate, setCurrentTemplate] = useState<TemplateQuestion>();
  // const getTemplates = () => {
  //   if (unitId) {
  //     templateQuestionApi.getAllByUnitId(unitId).then((res) => {
  //       if (res.status === 200) {
  //         setTemplate(res.data);
  //       } else {
  //         toastService.error(res.data.message);
  //         setTemplate([]);
  //       }
  //     });
  //   }
  // };
  useEffect(() => {
    setCurrentTemplate(null as any);
    if (unitId) {
      // getTemplates();
    } else {
      setTemplate([]);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [unitId]);
  return { templates, currentTemplate, setCurrentTemplate };
};
