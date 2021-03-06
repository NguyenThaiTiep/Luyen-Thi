import BoxApp from "app/components/_share/Box";
import { useGrades } from "hooks/Grade-Subject/useGrades";
import { useSubjects } from "hooks/Grade-Subject/useSubjects";
import { DocumentUpdateInfo } from "models/document/DocumentUpdateInfo";
import React, { useEffect, useState } from "react";
import { Button, Col, Form, Image, Row } from "react-bootstrap";
import Select from "react-select";
import { documentApi } from "services/api/document/documentApi";
import { toastService } from "services/toast";
import { documentForms } from "settings/document/documentForm";
import { shuffleTypes } from "settings/document/documentShuffle";
import { documentStatuses } from "settings/document/documentStatus";
import { documentTypes } from "settings/document/documentType";
import { getIdFromUrl, IsGoogleDocUrl } from "utils/urlFunction";
import "./style.scss";
import { uploadApi } from "services/api/upload/uploadCloundinary";
import UploadImageForm from "app/components/_share/Form/UploadImage/UploadImageForm";
import { useDocumentDetailContext } from "hooks/Document/DocumentDetailContext";
interface Props {
  documentId: string;
}
const DocumentEditInfo: React.FC<Props> = ({ documentId }) => {
  const { document, setQuestionSets } = useDocumentDetailContext();
  const [documentDetail, setDocumentDetail] = useState(document);
  const { grades } = useGrades();
  const { subjects } = useSubjects();
  const [updateEnable, setUpdateEnable] = useState(true);
  const importQuestionSet = () => {
    setUpdateEnable(false);
    const googleDocId = getIdFromUrl(documentDetail.googleDocId);
    documentApi
      .importQuestion({
        documentId: document.id,
        googleDocId,
        googleDocUrl: documentDetail.googleDocId,
      })
      .then((res: any) => {
        setUpdateEnable(true);
        if (res.status === 200) {
          toastService.success();
          setQuestionSets(res.data);
        } else {
          toastService.error(res.message);
        }
      });
  };
  const changeAvatar = (files: any) => {
    uploadApi.upload(files).then((res: any) => {
      if (res.status === 200) {
        const url = res.data.path;
        setDocumentDetail({ ...documentDetail, imageUrl: url });
      } else {
        toastService.error(res.message);
      }
    });
  };
  const updateDocument = () => {
    var documentUpdateInfo: DocumentUpdateInfo = {
      ...documentDetail,
      subjectId: documentDetail.subject.id,
      gradeId: documentDetail.grade.id,
      times: Math.abs(documentDetail.times) || 0,
    };
    setUpdateEnable(false);
    documentApi.update(documentUpdateInfo).then((res: any) => {
      setUpdateEnable(true);
      if (res.status === 200) {
        toastService.success("???? l??u");
      } else {
        toastService.error(res.message);
      }
    });
  };
  const approveDocument = () => {
    setUpdateEnable(false);
    documentApi.approve(documentDetail.id).then((res) => {
      setUpdateEnable(true);
      if (res.status === 200) {
        setDocumentDetail({ ...documentDetail, isApprove: true });
        toastService.success();
      } else {
        toastService.error(res.data);
      }
    });
  };
  useEffect(() => {
    setDocumentDetail(document);
  }, [document]);
  return (
    <BoxApp>
      <div className="document-edit-info">
        <div className="document-info-preview">
          <div className="label-document">TH??NG TIN T??I LI???U</div>
          {documentDetail && (
            <div className="document-info mt-3">
              <Form.Group className="mb-3">
                <Form.Label className="font-weight-bold">
                  T??n t??i li???u
                </Form.Label>
                <Form.Control
                  type="text"
                  placeholder="VD : ????? thi th??? THPT QG n??m 2020 s??? GD Th??i B??nh"
                  value={documentDetail.name}
                  spellCheck={false}
                  onChange={(e) =>
                    setDocumentDetail({
                      ...documentDetail,
                      name: e.target.value,
                    })
                  }
                />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label className="font-weight-bold">M?? t???</Form.Label>
                <Form.Control
                  className="document-description"
                  as="textarea"
                  rows={6}
                  value={documentDetail.description}
                  spellCheck={false}
                  onChange={(e) =>
                    setDocumentDetail({
                      ...documentDetail,
                      description: e.target.value,
                    })
                  }
                />
              </Form.Group>{" "}
              <Row className="row mb-3">
                <Form.Group as={Col} controlId="formGridEmail">
                  <Form.Label>L???p</Form.Label>
                  <Select
                    options={grades}
                    value={documentDetail.grade}
                    getOptionLabel={(e) => e.name}
                    getOptionValue={(e) => e.id as any}
                    onChange={(e: any) =>
                      setDocumentDetail({
                        ...documentDetail,
                        grade: e,
                      })
                    }
                  />
                </Form.Group>

                <Form.Group as={Col} controlId="formGridPassword">
                  <Form.Label>M??n</Form.Label>
                  <Select
                    options={subjects}
                    value={documentDetail.subject}
                    getOptionLabel={(e) => e.name}
                    getOptionValue={(e) => e.id as any}
                    onChange={(e: any) =>
                      setDocumentDetail({ ...documentDetail, subject: e })
                    }
                  />
                </Form.Group>
              </Row>
              <div className=" document-options d-flex">
                <div className="image-document text-center">
                  <Image
                    src={
                      documentDetail.imageUrl ||
                      "https://taiphanmem.com.vn/anhphanmem/20210520/dethieng2-2021-05-20.png"
                    }
                    width={200}
                    height={250}
                  />
                  <div className="pos-absolute image-editor">
                    <UploadImageForm onUpload={changeAvatar} />
                  </div>
                </div>
                <div className="  matrix-document" style={{ flexGrow: 1 }}>
                  <Row className="row mb-3">
                    <Form.Group as={Col} controlId="formGridEmail">
                      <Form.Label>Th??? lo???i</Form.Label>
                      <Select
                        options={documentTypes as any}
                        value={documentTypes.find(
                          (i) => i.value === documentDetail.documentType
                        )}
                        onChange={(e: any) =>
                          setDocumentDetail({
                            ...documentDetail,
                            documentType: e.value,
                          })
                        }
                      />
                    </Form.Group>

                    <Form.Group as={Col} controlId="formGridPassword">
                      <Form.Label>Ch??? ????? ng?????i xem</Form.Label>
                      <Select
                        options={documentStatuses as any}
                        value={documentStatuses.find(
                          (i) => i.value === documentDetail.status
                        )}
                        onChange={(e: any) =>
                          setDocumentDetail({
                            ...documentDetail,
                            status: e.value,
                          })
                        }
                      />
                    </Form.Group>
                  </Row>
                  <Row className="row mb-3">
                    <Form.Group as={Col} controlId="formGridEmail">
                      <Form.Label>H??nh th???c l??m b??i</Form.Label>
                      <Select
                        options={documentForms as any}
                        value={documentForms.find(
                          (i) => i.value === documentDetail.form
                        )}
                        onChange={(e: any) =>
                          setDocumentDetail({
                            ...documentDetail,
                            form: e.value,
                          })
                        }
                      />
                    </Form.Group>

                    <Form.Group as={Col} controlId="formGridPassword">
                      <Form.Label>Tr???n c??u h???i</Form.Label>
                      <Select
                        options={shuffleTypes as any}
                        value={shuffleTypes.find(
                          (i) => i.value === documentDetail.shuffleType
                        )}
                        onChange={(e: any) =>
                          setDocumentDetail({
                            ...documentDetail,
                            shuffleType: e.value,
                          })
                        }
                      />
                    </Form.Group>
                  </Row>
                  <Row className="row mb-3">
                    <Form.Group as={Col} controlId="formGridEmail">
                      <Form.Label>Th???i gian l??m b??i (ph??t)</Form.Label>

                      <Form.Control
                        placeholder="s??? ph??t"
                        type="number"
                        min={0}
                        value={documentDetail.times}
                        onChange={(e) =>
                          setDocumentDetail({
                            ...documentDetail,
                            times: e.target.value as any,
                          })
                        }
                      />
                    </Form.Group>

                    <Form.Group as={Col} controlId="formGridPassword">
                      <Form.Label>Tr???ng th??i</Form.Label>
                      <Form.Control
                        value={
                          documentDetail.isApprove ? "???? duy???t" : "Ch??a duy???t"
                        }
                        spellCheck={false}
                      />
                    </Form.Group>
                  </Row>
                </div>
              </div>
              <div className="btn-update text-right mt-4">
                <Button
                  className="mx-2"
                  variant="danger"
                  disabled={!updateEnable}
                >
                  X??a
                </Button>
                <Button
                  className="mx-2"
                  variant="success"
                  disabled={!updateEnable}
                  onClick={approveDocument}
                >
                  Duy???t
                </Button>

                <Button
                  className="mx-2"
                  variant="primary"
                  onClick={updateDocument}
                  disabled={!updateEnable}
                >
                  L??u
                </Button>
              </div>
              <hr className="mt-4" />
              <div className="update-data">
                <Form.Group className="mb-3">
                  <Form.Label className="font-weight-bold">
                    C???p nh???t d??? li???u
                  </Form.Label>
                  <Form.Control
                    className="document-google-doc"
                    spellCheck={false}
                    value={documentDetail.googleDocId}
                    onChange={(e) =>
                      setDocumentDetail({
                        ...documentDetail,
                        googleDocId: e.target.value as any,
                      })
                    }
                    placeholder="???????ng d???n t??i li???u google doc (ch??? ????? : m???i ng?????i c?? th??? s???a)"
                  />
                </Form.Group>
                <div className="btn-update text-center">
                  <Button
                    className="mx-2"
                    variant="outline-warning"
                    href={`/editor/matrix/${document.id}`}
                    target="_blank"
                  >
                    C???p nh???t ma tr???n
                  </Button>
                  <Button
                    className="mx-2"
                    variant="outline-warning"
                    href={`/editor/document/${document.id}`}
                    target="_blank"
                  >
                    S???a d??? li???u
                  </Button>
                  <Button
                    className="mx-2"
                    variant="outline-primary"
                    disabled={
                      !(
                        IsGoogleDocUrl(documentDetail.googleDocId) &&
                        updateEnable
                      )
                    }
                    onClick={importQuestionSet}
                  >
                    C???p nh???t
                  </Button>
                </div>
              </div>
            </div>
          )}
        </div>
      </div>
    </BoxApp>
  );
};

export default DocumentEditInfo;
