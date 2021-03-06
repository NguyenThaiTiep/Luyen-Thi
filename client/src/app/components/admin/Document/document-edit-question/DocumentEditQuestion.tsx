import React, { useState } from "react";
import { Grid, makeStyles, Theme } from "@material-ui/core";
import "./style.scss";
import DocumentTopBar from "app/components/_share/Menu/DocumentTopBar";
import { Route, Switch, useParams } from "react-router";
import { useQuestions } from "hooks/Question/useQuestions";
import QuestionMatrixSideBar from "app/components/sidebars/QuestionMatrixSideBar";
import QuestionEditor from "app/components/question/QuestionEditor";
import { DocumentEditContext } from "hooks/DocumentEditQuestionContext/DocumentEditContext";
import AddQuestionSetModal from "app/components/_share/Modals/AddQuestionSetModal";
import QuestionSetEdit from "app/components/question-set/QuestionSetEdit";
import QuestionEditSideBar from "app/components/sidebars/QuestionSideBar";
import QuestionDocument from "../SubjectDocument/DocumentDetail/question-documents/QuestionDocument";
const DocumentEditQuestion: React.FC = () => {
  const { id } = useParams<Params>();
  const [showModalAddQuestionSet, setShowModalAddQuestionSet] = useState(false);
  // const [documentInfo, setDocumentInfo] = useState<DocoumentTitle>();
  const documentState = useQuestions(id);
  const classes = useStyles();
  const [isMobileNavOpen, setMobileNavOpen] = useState(false);
  const value = {
    ...(documentState as any),
    showAddQuestionSetModal: () => setShowModalAddQuestionSet(true),
  };
  return (
    <DocumentEditContext.Provider value={value}>
      <div className={classes.root}>
        <div className="edit-questions-page">
          <DocumentTopBar onMobileNavOpen={() => setMobileNavOpen(true)} />
          <QuestionEditSideBar
            onMobileClose={() => setMobileNavOpen(false)}
            openMobile={isMobileNavOpen}
            questionSets={documentState.questionSets}
          />
          <div className={classes.wrapper}>
            <div className={classes.contentContainer}>
              <div className={classes.content}>
                <div className="main-content-document">
                  <Grid container>
                    <Grid item xl={9} lg={9} md={12}>
                      <Switch>
                        <Route path="/editor/document/:id/" exact={true}>
                          <div className="preview-questions ">
                            <QuestionDocument
                              documentId={id}
                              questionSets={documentState.questionSets}
                              setQuestionSets={documentState.setQuestionSets}
                              loading={documentState.loading}
                            />
                          </div>
                        </Route>
                        <Route
                          path="/editor/document/:id/:questionSetId"
                          exact={true}
                        >
                          <div className="edit-question ">
                            <QuestionSetEdit />
                          </div>
                        </Route>
                        <Route
                          path="/editor/document/:id/:questionSetId/:questionId"
                          exact={true}
                        >
                          <div className="edit-question ">
                            <QuestionEditor />
                          </div>
                        </Route>
                      </Switch>
                    </Grid>
                    <Grid item xl={3} lg={3} md={12}>
                      <Switch>
                        <Route
                          path="/editor/document/:id/:questionSetId/:questionId"
                          exact={true}
                        >
                          <QuestionMatrixSideBar />
                        </Route>
                      </Switch>
                    </Grid>
                  </Grid>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <AddQuestionSetModal
        show={showModalAddQuestionSet}
        setShow={setShowModalAddQuestionSet}
        onAdd={documentState.addQuestionSet}
      />
    </DocumentEditContext.Provider>
  );
};
interface Params {
  id: string;
}
const useStyles = makeStyles((theme: Theme) => ({
  root: {
    backgroundColor: "#F4F6F8",
    display: "flex",
    height: "100%",
    overflow: "hidden",
    width: "100%",
  },
  wrapper: {
    display: "flex",
    flex: "1 1 auto",
    overflow: "hidden",
    paddingTop: 64,
    [theme.breakpoints.up("lg")]: {
      paddingLeft: 325,
    },
  },
  contentContainer: {
    display: "flex",
    flex: "1 1 auto",
    overflow: "hidden",
  },
  content: {
    flex: "1 1 auto",
    height: "100%",
    overflowY: "auto",
    overflowX: "hidden",
  },
})) as any;

export default DocumentEditQuestion;
