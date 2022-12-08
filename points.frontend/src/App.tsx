import React from "react";
import { useEffect } from "react";
import { getInitializedStatus } from "./redux/app-selector";
import { getPoints } from "./redux/points-selector";
import { connect } from "react-redux";
import { initializeThunkCreator } from "./redux/app-reducer";
import { Point } from "./components/point/Point";
import { deletePointThunkCreator } from "./redux/point-reducer";
import { IPoint } from "./types/types";
import type { RootState } from './redux/store'

interface IAppProps {
  initialized: boolean;
  points: IPoint[];
  initializeThunkCreator: () => Promise<void>;
  deletePointThunkCreator: (pointId: string) => Promise<void>;
}

const App: React.FC<IAppProps> = (props) => {
  useEffect(() => {
    props.initializeThunkCreator();
  }, []);

  return props.initialized ? (
    <>
      {props.points.map((point: IPoint) => {
        return (
          <Point
            key={point.id}
            point={point}
            onDeletePoint={props.deletePointThunkCreator}
          />
        );
      })}
    </>
  ) : (
    <div>Loader</div>
  );
};

const mapStateToProps = (state: RootState) => {
  return {
    initialized: getInitializedStatus(state),
    points: getPoints(state),
  };
};

export default connect(mapStateToProps, {
  initializeThunkCreator,
  deletePointThunkCreator,
})(App);
