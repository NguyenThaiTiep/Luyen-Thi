import { faEnvelope, faPhoneAlt } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Facebook, GitHub, YouTube } from "@material-ui/icons";
import { history } from "services/history";
import qs from "query-string";
import React from "react";
import { makeStyles, Theme } from "@material-ui/core";
import { Col, Container, Row } from "react-bootstrap";
import "./style.scss";
const AppFooter = () => {
  const classes = useStyles();
  const navigateGrade = (gradeCode: string) => {
    history.push({
      pathname: "/document",
      search: qs.stringify({
        gradeCode: gradeCode,
      }),
    });
  };
  const navigateSubject = (subjectCode: string) => {
    history.push({
      pathname: "/document",
      search: qs.stringify({
        subjectCode: subjectCode,
      }),
    });
  };
  const navigateYoutube = () =>
    window.open(
      "https://www.youtube.com/watch?v=uWNiD3rumHk&ab_channel=KasanoKai",
      "_blank"
    );
  const navigateGithub = () =>
    window.open("https://github.com/NguyenThaiTiep", "_blank");
  const navigateFacebook = () =>
    window.open("https://www.facebook.com/nguyenthaitiep.206", "_blank");

  return (
    <div className="app-footer">
      <Container>
        <Row>
          <Col lg={4} md={6}>
            <div className="logo-label mb-3">iPractice</div>
            <div className="d-flex mt-1">
              <span className="icon-label">
                <FontAwesomeIcon icon={faPhoneAlt} />
              </span>
              <span>(+84) 819 200 620</span>
            </div>
            <div className="d-flex mt-1">
              <span className="icon-label">
                <FontAwesomeIcon icon={faEnvelope} />
              </span>
              <span>luyenthisp@gmail.com</span>
            </div>
            <div className="d-flex mt-2 social">
              <span className="icon-social">
                <Facebook
                  className={classes.activeLink}
                  onClick={navigateFacebook}
                />
              </span>
              <span className="icon-social mx-2">
                <GitHub
                  className={classes.activeLink}
                  onClick={navigateGithub}
                />
              </span>
              <span className="icon-social mx-2">
                <YouTube
                  className={classes.activeLink}
                  onClick={navigateYoutube}
                />
              </span>
            </div>
          </Col>
          <Col lg={4} md={6} className="mt-3">
            <div className="label mb-2">????? thi theo m??n</div>
            <Row>
              <Col lg={6} md={6} xs={6}>
                <div
                  className={classes.activeLink}
                  onClick={() => navigateSubject("math")}
                >
                  To??n h???c
                </div>
                <div
                  className={classes.activeLink}
                  onClick={() => navigateSubject("english")}
                >
                  Ti???ng Anh
                </div>
                <div
                  className={classes.activeLink}
                  onClick={() => navigateSubject("physics")}
                >
                  V???t l??
                </div>
                <div
                  className={classes.activeLink}
                  onClick={() => navigateSubject("chemistry")}
                >
                  H??a h???c
                </div>
              </Col>
              <Col lg={6} md={6} xs={6}>
                <div
                  className={classes.activeLink}
                  onClick={() => navigateSubject("biology")}
                >
                  Sinh h???c
                </div>
                <div
                  className={classes.activeLink}
                  onClick={() => navigateSubject("history")}
                >
                  L???ch s???
                </div>
                <div
                  className={classes.activeLink}
                  onClick={() => navigateSubject("geography")}
                >
                  ?????a l??
                </div>
                <div
                  className={classes.activeLink}
                  onClick={() => navigateSubject("civic-education")}
                >
                  Gi??o d???c c??ng d??n
                </div>
              </Col>
            </Row>
          </Col>
          <Col lg={2} md={6} xs={6} className="mt-3">
            <Row>
              <div className="label mb-2">??n luy???n</div>
              <div
                className={classes.activeLink}
                onClick={() => navigateGrade("grade-10")}
              >
                L???p 10
              </div>
              <div
                className={classes.activeLink}
                onClick={() => navigateGrade("grade-11")}
              >
                L???p 11
              </div>
              <div
                className={classes.activeLink}
                onClick={() => navigateGrade("grade-12")}
              >
                L???p 12
              </div>
              <div className="mt-1">??n thi THPT Qu???c gia</div>
            </Row>
          </Col>
          <Col lg={2} md={6} xs={6} className="mt-3">
            <Row>
              <div className="label mb-2">H??? tr???</div>
              <div className="mt-1">B??o c??o</div>
              <div className="mt-1">H?????ng d???n s??? d???ng</div>
              <div className="mt-1">Nh??m h??? tr??? h???c t???p</div>
            </Row>
          </Col>
        </Row>
      </Container>
    </div>
  );
};
const useStyles = makeStyles((theme: Theme) => ({
  activeLink: {
    cursor: "pointer",
    marginTop: "1px",
  },
})) as any;

export default AppFooter;
